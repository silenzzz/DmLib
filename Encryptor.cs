using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DmLib
{
    public static class Encryptor
    {
        private static readonly byte[] DEFAULT_SALT = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        /// <summary>
        /// Encrypts the specified string.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <param name="password">Password.</param>
        /// <returns> Encrypted string </returns>
        public static string Encrypt(string s, string password)
        {
            if (s == null)
            {
                return null;
            }

            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(s);
            var passwordBytes = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(password));
            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);
            return Convert.ToBase64String(bytesEncrypted);
        }

        /// <summary>
        /// Decrypts the specified string.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <param name="password">Password.</param>
        /// <returns> Dencrypted string </returns>
        public static string Decrypt(string s, string password)
        {
            if (s == null)
            {
                return null;
            }

            var bytesToBeDecrypted = Convert.FromBase64String(s);
            var passwordBytes = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(password));
            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);
            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, DEFAULT_SALT, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, DEFAULT_SALT, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }
    }
}

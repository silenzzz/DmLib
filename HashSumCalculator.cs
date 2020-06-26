using System;
using System.Security.Cryptography;
using System.Text;

namespace DmLib
{
    public static class HashCalculator
    {
        /// <summary>
        /// Gets the string MD5 hash sum.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns>String md5 hash sum</returns>
        public static string GetStringMd5Hash(string s)
        {
            string hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = BitConverter.ToString(
                  md5.ComputeHash(Encoding.UTF8.GetBytes(s))
                ).Replace("-", string.Empty);
            }
            return hash;
        }

        /// <summary>
        /// Gets the string sha256 hash sum.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns>String sha256 hash sum</returns>
        public static string GetStringSha256Hash(string s)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(s)); 
                var res = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    res.Append(bytes[i].ToString("x2"));
                }
                return res.ToString();
            }
        }

        /// <summary>
        /// Gets the string sha1 hash sum.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns>String sha1 hash sum</returns>
        public static string GetStringSha1Hash(string s)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(s));
                var res = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                {
                    res.Append(b.ToString("X2"));
                }
                return res.ToString();
            }
        }
    }
}

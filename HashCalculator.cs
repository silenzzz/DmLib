using System;
using System.Text;

namespace DmLib
{
    public static class HashCalculator
    {
        /// <summary>
        /// Gets the string MD5 hash sum.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns> Hash sum </returns>
        public static string GetStringMd5Hash(string s)
        {
            string hash;
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                hash = BitConverter.ToString(
                  md5.ComputeHash(Encoding.UTF8.GetBytes(s))
                ).Replace("-", string.Empty);
            }
            return hash;
        }
    }
}

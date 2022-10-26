using System;
using System.Security.Cryptography;
using System.Text;

namespace FlakeyBit.DigestAuthentication.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    internal static class MD5HashExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToMD5Hash(this byte[] bytes) {
            var hashBytes = MD5.Create().ComputeHash(bytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string ToMD5Hash(this string inputString) {
            return Encoding.UTF8.GetBytes(inputString).ToMD5Hash();
        }
    }
}
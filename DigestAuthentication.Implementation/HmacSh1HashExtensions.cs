using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FlakeyBit.DigestAuthentication.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    internal static class HmacSh1HashExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ToHashMacSha1(this byte[] bytes, byte[] key)
        {
            var myhmacsha1 = new HMACSHA1(key);            
            var stream = new MemoryStream(bytes);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ToHashMacSha1(this string inputString, byte[] key)
        {
            var myhmacsha1 = new HMACSHA1(key);
            var byteArray = Encoding.ASCII.GetBytes(inputString);
            var stream = new MemoryStream(byteArray);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }
    }
}

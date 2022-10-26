using Microsoft.AspNetCore.Http;
using Root.Models;
using System;

namespace Root.Helpers
{
    public static class HttpContextHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static IHttpContextAccessor Accessor;

        /// <summary>
        /// 
        /// </summary>
        public static HttpContext Current => Accessor?.HttpContext;

        /// <summary>
        /// 
        /// </summary>
        public static void SetErrorInBodyCode()
        {
            SetStatusCode(ResponseStatusCode.ErrorInBody);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        public static void SetStatusCode(ResponseStatusCode code)
        {
            var responseCode = (int)Enum.ToObject(code.GetType(), code);
            SetStatusCode(responseCode);
        }
        /// <summary>
        /// return code status
        /// </summary>
        /// <param name="code"></param>
        public static int GetStatusCode(ResponseStatusCode code)
        {
            var responseCode = (int)Enum.ToObject(code.GetType(), code);
            SetStatusCode(responseCode);
            return responseCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        public static void SetStatusCode(int code)
        {
            if (Current?.Response != null)
                Current.Response.StatusCode = code;
        }
    }
}

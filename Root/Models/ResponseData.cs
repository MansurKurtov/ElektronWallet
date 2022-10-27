using Newtonsoft.Json;
using Root.Helpers;
using System.Net;

namespace Root.Models
{
    /// <summary>
    /// Этот класс использует для возврата результатов запроса
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ResponseData(int code, string message, bool success)
        {
            Code = code;
            Message = message;
            Data = null;
            Success = success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public ResponseData(ResponseData response)
        {
            if (response.Code != 200)
                HttpContextHelper.SetStatusCode(HttpStatusCode.InternalServerError);
            else
                HttpContextHelper.SetStatusCode(HttpStatusCode.OK);

            Code = response.Code;
            Message = response.Message;
            Data = null;
            Success = response.Success;
        }

        public ResponseData(ResponseData response, object data)
        {
            if (response.Code != 200)
                HttpContextHelper.SetStatusCode(HttpStatusCode.InternalServerError);
            else
                HttpContextHelper.SetStatusCode(HttpStatusCode.OK);

            Code = response.Code;
            Message = response.Message;
            Success = response.Success;
            Data = data;
        }

        public ResponseData()
        {

        }

    }

    public static class ResponseStatus
    {
        public static readonly ResponseData Ok = new ResponseData(200, "Ok", true);

        public static readonly ResponseData Created = new ResponseData(201, "Created", true);

        public static readonly ResponseData BadRequest = new ResponseData(400, "Bad request", false);

        public static readonly ResponseData Unauthorized = new ResponseData(401, "Unauthorized", false); //неавторизован

        public static readonly ResponseData Forbidden = new ResponseData(403, "Forbidden", false); //запрещено

        public static readonly ResponseData NotFound = new ResponseData(404, "Not found", false);

        public static readonly ResponseData Conflict = new ResponseData(409, "Already exists", false);

        public static readonly ResponseData InvalidParameters = new ResponseData(444, "Invalid parameters", false);

        public static readonly ResponseData InternalServerError = new ResponseData(500, "Internal Server Error", false);


        public static readonly ResponseData InvalidUserInformation = new ResponseData(901, "Invalid user information", false);

        public static readonly ResponseData InvalidPassword = new ResponseData(902, "Invalid password information", false);

        public static readonly ResponseData CannotAddToken = new ResponseData(903, "Cannot add token to database", false);

        public static readonly ResponseData CannotRefreshToken = new ResponseData(904, "Can not refresh token", false);

        public static readonly ResponseData RefreshTokenExpired = new ResponseData(905, "Refresh token has expired", false);

        public static readonly ResponseData CannotExpireTokenCreate = new ResponseData(906, "Cannot expire token or create a new token", false);

    }
}

namespace Root.Models
{
    /// <summary>
    /// 
    /// </summary>
    public enum ResponseStatusCode
    {
        /// <summary>
        /// Хорошо
        /// </summary>
        OK = 200,

        /// <summary>
        /// Создано
        /// </summary>
        Created = 201,

        /// <summary>
        /// Принято
        /// </summary>
        Accepted = 202,

        /// <summary>
        /// Принято
        /// </summary>
        NoContent = 204,

        /// <summary>
        /// Найдено
        /// </summary>
        Found = 302,

        /// <summary>
        /// Плохой, неверный запрос
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Не авторизован
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// Запрещено (не уполномочен)
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// Не найдено
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Конфликт
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// Отправляется ошибка в теле
        /// </summary>
        ErrorInBody = 444,

        /// <summary>
        /// Send sms
        /// </summary>
        SendSms = 484,

        /// <summary>
        /// Внутренняя ошибка сервера
        /// </summary>
        InternalServerError = 500
    }
}

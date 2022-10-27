using System;

namespace EWalletService.Helpers
{
    /// <summary>
    /// Этот вспомогательный класс помогает получить 
    /// статические данные сервера для некоторых случаев использования.
    /// </summary>
    public class ServerDataHelper
    {
        /// <summary>
        /// Возвращает время сервера
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            //TODO: Here we should return server time
            return DateTime.Now;
        }

        /// <summary>
        /// Возвращает текущий номер месяца на сервере
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentMonthNumber()
        {
            return DateTime.Today.Month;
        }
    }
}

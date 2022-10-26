using System;

namespace EWalletService.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class ServerDataHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            //TODO: Here we should return server time
            return DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentMonthNumber()
        {
            return DateTime.Today.Month;
        }
    }
}

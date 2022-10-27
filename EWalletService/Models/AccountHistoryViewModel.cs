using Root.TmpData;
using System;

namespace EWalletService.Models
{
    /// <summary>
    /// ViewModel для возврата истории учетной 
    /// записи по информации об операциях
    /// </summary>
    public class AccountHistoryViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public AccountHistoryViewModel()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public AccountHistoryViewModel(AccountHistory entity)
        {
            OperationTime = entity.OperationTime;
            Amount = entity.Amount;
        }

        /// <summary>
        /// Время операции
        /// </summary>
        public DateTime OperationTime { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public double Amount { get; set; }
    }
}

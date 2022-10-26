using Root.TmpData;
using System;

namespace EWalletService.Models
{
    /// <summary>
    /// 
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
        /// 
        /// </summary>
        public DateTime OperationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Amount { get; set; }
    }
}

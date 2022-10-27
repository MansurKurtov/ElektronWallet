using EWalletService.Models;
using Root.Models;
using System.Threading.Tasks;

namespace EWalletService.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IElectronWalletService
    {
        /// <summary>
        /// существует ли аккаунт электронного кошелька
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<AccountExistanceViewModel> IsAccountAxistsAsync(string accountNumber);

        /// <summary>
        /// Пополнение электронного кошелька.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<ResponseData> ReplenishAccountAsync(ReplenishPostModel data);

        /// <summary>
        /// Получить общее количество и суммы операций пополнения за текущий месяц
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<ResponseData> GetAccountHistoryForCurrentMonthAsync(string accountNumber);

        /// <summary>
        /// Получить баланс электронного кошелька
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<ResponseData> GetBalanceAsync(string accountNumber);

        
        
    }
}
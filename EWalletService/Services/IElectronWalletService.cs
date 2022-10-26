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
        Task<AccountExistanceViewModel> IsAccountAxists(string accountNumber);

        /// <summary>
        /// Пополнение электронного кошелька.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<ResponseData> ReplenishAccount(ReplenishPostModel data);

        /// <summary>
        /// Получить общее количество и суммы операций пополнения за текущий месяц
        /// </summary>
        /// <returns></returns>
        Task<ResponseData> GetAccountHistoryForCurrentMonth();

        /// <summary>
        /// Получить баланс электронного кошелька
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<ResponseData> GetBalance(string accountNumber);

        
        
    }
}
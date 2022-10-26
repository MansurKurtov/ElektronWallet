using EWalletService.Helpers;
using EWalletService.Models;
using Root.Models;
using Root.TmpData;
using System.Linq;
using System.Threading.Tasks;

namespace EWalletService.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ElectronWalletService : IElectronWalletService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<AccountExistanceViewModel> IsAccountAxists(string accountNumber)
        {
            var item = MyFakeDataBase.Accounts.FirstOrDefault(f => f.AccountNumber == accountNumber);
            var result = new AccountExistanceViewModel();
            result.IsAccountExist = item != null;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<ResponseData> ReplenishAccount(ReplenishPostModel data)
        {
            var account = MyFakeDataBase.Accounts.FirstOrDefault(f => f.AccountNumber == data.AccountNumber);
            if (account == null)
                return new ResponseData(ResponseStatus.NotFound, "Account not found(");

            account.Balance += data.Amount;

            MyFakeDataBase.AccountHistories.Add(new AccountHistory()
            {
                AccointId = account.Id,
                Amount = data.Amount,
                OperationTime = ServerDataHelper.GetServerTime()
            });

            var result = new ReplenishViewModel();
            result.AccountId = account.Id;

            return new ResponseData(ResponseStatus.Ok, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseData> GetAccountHistoryForCurrentMonth()
        {
            var currentMonth = ServerDataHelper.GetCurrentMonthNumber();
            var items = MyFakeDataBase.AccountHistories.Where(w => w.OperationTime.Month == currentMonth).ToList();
            var result = items?.Select(s => new AccountHistoryViewModel(s)).ToList();

            return new ResponseData(ResponseStatus.Ok, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<ResponseData> GetBalance(string accountNumber)
        {
            var account = MyFakeDataBase.Accounts.FirstOrDefault(f => f.AccountNumber == accountNumber);
            if (account == null)
                return new ResponseData(ResponseStatus.NotFound, "Account not found(");

            var result = new AccountBalanceViewModel();
            result.Balance = account.Balance;
            return new ResponseData(ResponseStatus.Ok, result);
        }
    }
}

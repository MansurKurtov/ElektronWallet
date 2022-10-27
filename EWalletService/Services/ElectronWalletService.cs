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
        private const double LimitForIdentUser = 10000;

        /// <summary>
        /// 
        /// </summary>
        private const double LimitForUnIdentUser = 100000;

        /// <summary>
        /// Этот метод помогает проверить существование аккаунта
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<AccountExistanceViewModel> IsAccountAxistsAsync(string accountNumber)
        {
            var item = MyFakeDataBase.Accounts.FirstOrDefault(f => f.AccountNumber == accountNumber);
            var result = new AccountExistanceViewModel();
            result.IsAccountExist = item != null;

            return result;
        }

        /// <summary>
        /// Пополнить счет
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<ResponseData> ReplenishAccountAsync(ReplenishPostModel data)
        {
            var account = MyFakeDataBase.Accounts.FirstOrDefault(f => f.AccountNumber == data.AccountNumber);
            if (account == null)
                return new ResponseData(ResponseStatus.NotFound, "Account not found(");


            // проверка: максимальный баланс составляет 10.000 сомони для неидентифицированных счетов и
            // 100.000 сомони для идентифицированных счетов
            if ((account.Balance>=LimitForIdentUser && account.AccountType == AccountType.Identified) || 
                    (account.Balance >= LimitForUnIdentUser && account.AccountType == AccountType.Unidentified))
                return new ResponseData(ResponseStatus.BadRequest, "Limit error");

            

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
        /// Получить отчет об операциях по счету за текущий месяц
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<ResponseData> GetAccountHistoryForCurrentMonthAsync(string accountNumber)
        {
            var currentMonth = ServerDataHelper.GetCurrentMonthNumber();
            var account = MyFakeDataBase.Accounts.FirstOrDefault(f => f.AccountNumber == accountNumber);
            if (account == null)
                return new ResponseData(ResponseStatus.NotFound, "Account not found(");

            var items = MyFakeDataBase.AccountHistories.Where(w => w.AccointId == account.Id && w.OperationTime.Month == currentMonth).ToList();
            var result = items?.Select(s => new AccountHistoryViewModel(s)).ToList();

            return new ResponseData(ResponseStatus.Ok, result);
        }

        /// <summary>
        /// Получить информацию о балансе по номеру счета
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<ResponseData> GetBalanceAsync(string accountNumber)
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

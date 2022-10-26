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
    public class ElectronWalletService
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
            var result = new ReplenishViewModel();
            result.Balance = account.Balance;
            return new ResponseData(ResponseStatus.Ok, result);
        }
    }
}

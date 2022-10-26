using System.Collections.Generic;

namespace Root.TmpData
{
    public class MyFakeDataBase
    {
        public static IEnumerable<EWAccount> Accounts = new List<EWAccount>
        {
            new EWAccount(){Id=1, AccountNumber="123456", AccountType = AccountType.Identified, Balance =0.90, HolderName = "Mansur"},
            new EWAccount(){Id=2, AccountNumber="223456", AccountType=AccountType.Unidentified, Balance=100, HolderName = "Mansur" },
            new EWAccount(){Id=3, AccountNumber="323456", AccountType=AccountType.Unidentified, Balance=1000000, HolderName = "Mansur"},
            new EWAccount(){Id=4, AccountNumber="423456", AccountType=AccountType.Identified, Balance=1, HolderName = "Mansur"},
            new EWAccount(){Id=5, AccountNumber="523456", AccountType=AccountType.Unidentified, Balance=100000, HolderName = "Mansur"}
        };

        public static List<AccountHistory> AccountHistories = new List<AccountHistory>();
    }
}

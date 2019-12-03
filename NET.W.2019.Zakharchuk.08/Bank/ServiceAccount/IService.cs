using AccountInfo;
using System.Collections.Generic;

namespace ServiceAccount
{
    interface IService
    {
        IEnumerable<Account> GetAllAccounts();
        void AddAmount(int id, decimal amount);
        void WithdrowAmount(int id, decimal amount);
        void CloseAccount(int id);
        void CreateAccount(Account account);
    }
}

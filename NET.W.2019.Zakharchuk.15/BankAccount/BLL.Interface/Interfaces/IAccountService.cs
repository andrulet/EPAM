using System;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        Account CreateAccount(AccountType account, string firstName, string lastName, decimal amount);

        void AddMoney(Account account, decimal money);

        void AddMoney(string account, decimal money);

        void WithdrawMoney(Account account, decimal money);

        void WithdrawMoney(string accountId, decimal money);

        void CloseAccount(Account account);

        void CloseAccout(string accountId);

        string GetAccount(string accountId);
    }
}

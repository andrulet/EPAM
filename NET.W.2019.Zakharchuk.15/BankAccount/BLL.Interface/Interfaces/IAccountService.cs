using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        Account OpenAccount(string owner, AccountType accountType, IAccountGetId accountGetId);
        void DepositMoney(int id, decimal money);      
        void WithdrawMoney(int id, decimal money);
        void CloseAccount(Account account);
        IEnumerable<Account> GetAccounts();
    }
}

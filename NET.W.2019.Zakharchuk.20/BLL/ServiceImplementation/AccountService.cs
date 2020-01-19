using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Describes the ability to manage accounts.
    /// </summary>
    public class AccountService : IAccountService
    {
        
        private readonly IRepository _accountRepsitory;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="accountRepsitory">The Interface reference on <see cref="IRepository"/></param>        
        public AccountService(IRepository accountRepsitory)
        {
            _accountRepsitory = accountRepsitory;            
        }

        /// <summary>
        /// Add money to account.
        /// </summary>
        /// <param name="Id">Id of the Account.</param>
        /// <param name="money">Deposit feom Score.</param>        
        public void DepositMoney(int id, decimal money)
        {
            if (id < 0 || id > int.MaxValue)
            {
                throw new ArgumentException($"{nameof(id)} less 0 or more {int.MaxValue}.");
            }
            if (money < 0 || money > decimal.MaxValue)
            {
                throw new ArgumentException($"{nameof(id)} less 0 or more {decimal.MaxValue}.");
            }

            var account = GetAccount(id);
            account.DepositToScore(money);
            _accountRepsitory.UpdateAccount(account.ConvertToDalAccount());
        }

        /// <summary>
        /// Withdraw money from account.
        /// </summary>
        /// <param name="id">Id of the Account.</param>
        /// <param name="money">Withdraw from Score.</param>       
        public void WithdrawMoney(int id, decimal money)
        {
            if (id < 0 || id > int.MaxValue)
            {
                throw new ArgumentException(nameof(id));
            }

            var account = GetAccount(id);
            account.WithdrawalFromScore(money);
            _accountRepsitory.UpdateAccount(account.ConvertToDalAccount());
        }

        /// <summary>
        /// Delete account.
        /// </summary>
        /// <param name="account">The account that mast close.</param>
        public void CloseAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            _accountRepsitory.RemoveAccount(account.ConvertToDalAccount());
        }       

        /// <summary>
        /// Get Account from storage.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>New Instance of Account.</returns>
        public Account GetAccount(int id)
        {           
            var account = _accountRepsitory.GetAccounts().FirstOrDefault(acc => acc.Id == id);
            if (account is null)
            {
                throw new ArgumentException($"Account with id {id} not found");
            }

            return account.ToAccount();
        }

        /// <summary>
        /// Gets accounts from storagy.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> GetAccounts()
        {
            var accounts = new List<Account>();
            foreach(var x in _accountRepsitory.GetAccounts())
            {
                accounts.Add(x.ToAccount());
            }

            return accounts;
        }

        /// <summary>
        /// Create new account.
        /// </summary>
        /// <param name="owner">Name and Surname of a peson? who want to create a new Score.</param>
        /// <param name="accountType">Type Account.</param>
        /// <param name="accountGetId">Number of score.</param>
        /// <returns>New Instance of Account.</returns>        
        public Account OpenAccount(string owner, AccountType accountType, IAccountGetId accountGetId)
        {
            var fullName = owner.Split(new char[] { ' ' }, 2);
            Account account;
            switch (accountType)
            {
                case AccountType.Base:
                    account = new BaseAccount(accountGetId.GetId(), fullName[0], fullName[1]);
                    break;
                case AccountType.Gold:
                    account = new GoldAccount(accountGetId.GetId(), fullName[0], fullName[1]);
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount (accountGetId.GetId(), fullName[0], fullName[1]);
                    break;
                default:
                    throw new ArgumentException(nameof(accountType));
            }

            _accountRepsitory.AddAccount(account.ConvertToDalAccount());
            return account;
        }             
    }
}

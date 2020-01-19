using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.EF.Entities;
using DAL.EF.Mapper;
using DAL.EF;



namespace DAL.EF
{
    public class AccountStorageEF : IRepository
    {
        AccountContext context = new AccountContext();      

        /// <summary>
        /// Add a new account to the repository.
        /// </summary>
        /// <param name="account">New account.</param>
        public void AddAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            context.AccountEFs.Add(account.ConvertToAccountEF());
            context.SaveChanges();
        }

        /// <summary>
        /// Return all BankAccount <see cref="DalAccount"/> from the repository.
        /// </summary>
        /// <returns>Account <see cref="BankAccount"/> from the repository.</returns>       
        public List<DalAccount> GetAccounts()
        {
            var list = new List<AccountEF>();
            using (var context = new AccountContext())
            {
                list.AddRange(context.AccountEFs);
            }

            return list.Select(acc => acc.ConvertToDaLAccount()).ToList();
        }

        /// <summary>
        /// A method that removes a account <paramref name="account"/> from the repository.
        /// </summary>
        /// <param name="account">The Account for removal.</param> 
        public void RemoveAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            using (var context = new AccountContext())
            {
                var accountForRemove = FindAccount(account, context);

                if (accountForRemove == null)
                {
                    throw new ArgumentNullException(nameof(accountForRemove));
                }

                context.AccountEFs.Remove(accountForRemove);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update the account information in the repository.
        /// </summary>
        /// <param name="account">Account to update.</param>        
        public void UpdateAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            using (var context = new AccountContext())
            {
                var accountForUpdate = FindAccount(account, context);

                if (accountForUpdate == null)
                {
                    throw new ArgumentNullException(nameof(accountForUpdate));
                }

                accountForUpdate.Score = account.Score;
                accountForUpdate.BonusPoint = account.BonusPoint;

                context.SaveChanges();
            }
        }

        private AccountEF FindAccount(DalAccount account, AccountContext context)
        {
            return context.AccountEFs.FirstOrDefault(acc => acc.Id == account.Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using AccountInfo;
using StorageAccount;

namespace ServiceAccount
{
    public class Service : IService
    {
        /// <summary>
        /// class instance that has information about accounts.
        /// </summary>
        private readonly Storage _storage;

        /// <summary>
        /// Constructor service that activate default path of storage.
        /// </summary>
        public Service()
        {
            _storage = new Storage();
        }

        /// <summary>
        /// Constructor service that activate given path of storage.
        /// </summary>
        public Service(string path)
        {
            _storage = new Storage();
        }

        /// <summary>
        /// This method add money into account by Id.
        /// <param name="id">Number of account.</param>
        /// <param name="amount">Sum of money that added on account.</param>
        /// </summary>
        public void AddAmount(int id, decimal amount)
        {            
            if (id < 0)
            {
                throw new ArgumentException("Enter incorrect id");
            }

            if (amount < 0)
            {
                throw new ArgumentException("Enter incorrect amount");
            }

            Account account = FindAccount(id);            
            if (account.Status == StatusAccount.Close)
            {
                throw new ArgumentException("Account is closed");
            }

            List<Account> accounts = DeleteAccountFromList(id);
            if (account.Type == TypeAccount.Base)
            {
                account.Amount += amount;
                account.Bonus += (int)amount / 20; 
            }

            if (account.Type == TypeAccount.Gold)
            {
                account.Amount += amount;
                account.Bonus += (int)amount / 10;
            }

            if (account.Type == TypeAccount.Platium)
            {
                account.Amount += amount;
                account.Bonus += (int)amount / 5;
            }

            accounts.Add(account);
            _storage.OverWriteFile(accounts);
        }

        /// <summary>
        /// This method removes money into account by Id.
        /// <param name="id">Number of account.</param>
        /// <param name="amount">Sum of money that removed from account.</param>
        /// </summary>
        public void WithdrowAmount(int id, decimal amount)
        {
            if (id < 0)
            {
                throw new ArgumentException("Enter incorrect id");
            }

            if (amount < 0)
            {
                throw new ArgumentException("Enter incorrect amount");
            }

            Account account = FindAccount(id);
            List<Account> accounts = DeleteAccountFromList(id);
            if (account.Status == StatusAccount.Close)
            {
                throw new ArgumentException("Account is closed");
            }

            if (account.Status == StatusAccount.Close)
            {
                throw new ArgumentException("Account is closed");
            }

            if (amount > account.Amount)
            {
                throw new ArgumentException("Insufficient funds");
            }

            account.Amount -= amount;
            accounts.Add(account);
            _storage.OverWriteFile(accounts);
        }

        /// <summary>
        /// This method close account by Id.
        /// <param name="id">Number of account.</param>        
        /// </summary>
        public void CloseAccount(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Enter incorrect id");
            }

            List<Account> accounts = _storage.ReadAccountFromFile().ToList();
            Account account = FindAccount(id);
            accounts.Remove(account);
            _storage.OverWriteFile(accounts);
        }

        /// <summary>
        /// This method create account by Account.
        /// <param name="id">Number of account.</param>
        /// </summary>
        public void CreateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentException("Entered incorrect account");
            }

            if (account.Equals(FindAccount(account.Id)))
            {
                throw new ArgumentException("This account already exists");
            }

            _storage.WriteAccountToFile(account);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _storage.ReadAccountFromFile();
        }

        /// <summary>
        /// This method finds account by Id in storage.        
        /// </summary>
        /// <param name="id">Number of account.</param>
        /// <returns>Correct Account</returns>
        private Account FindAccount(int id)
        {
            List<Account> accounts = _storage.ReadAccountFromFile().ToList();
            return accounts.FirstOrDefault(account => account.Id == id);
        }

        /// <summary>
        /// This method remove account from list of Accounts.        
        /// </summary>
        /// <param name="id">Number of account that needed remove from list of Accounts.</param>
        /// <returns>Correct list of Account</returns>
        private List<Account> DeleteAccountFromList(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Enter incorrect id");
            }

            List<Account> accounts = _storage.ReadAccountFromFile().ToList();
            Account account = FindAccount(id);
            accounts.Remove(account);
            return accounts;
        }
    }
}

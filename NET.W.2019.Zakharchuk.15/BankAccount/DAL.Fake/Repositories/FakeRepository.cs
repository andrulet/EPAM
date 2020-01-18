using System;
using System.Collections.Generic;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace DAL.Fake.Repositories
{
    public class FakeRepository : IRepository
    {
        private readonly List<DalAccount> accounts = new List<DalAccount>();

        public void AddAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }
            if (accounts.Find(acc => acc.Id == account.Id) != null)
            {
                throw new ArgumentException($"{nameof(account)} contains in storage.");
            }
            accounts.Add(account);
        }

        public DalAccount GetAccount(int id)
        {
            if (accounts.Find(acc => acc.Id == id) == null)
            {
                throw new ArgumentException($"Account with {nameof(id)} = {id} contains in storage.");
            }
            if (id < 0 || id > int.MaxValue)
            {
                throw new ArgumentException($"{nameof(id)} less 0 or more {int.MaxValue}");
            }
            return accounts.Find(acc => acc.Id == id);
        }

        public List<DalAccount> GetAccounts()
        {
            return accounts;
        }

        public void RemoveAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }
            var searchAccount = GetAccount(account.Id);
            accounts.Remove(searchAccount);
        }

        public void UpdateAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} is null");
            }
            var searchAccount = GetAccount(account.Id);
            RemoveAccount(searchAccount);
            AddAccount(account);
        }
    }
}

using System;
using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        void AddAccount(DalAccount account);
        void RemoveAccount(DalAccount account);
        List<DalAccount> GetAccounts();
        DalAccount GetAccount(int id);
        void UpdateAccount(DalAccount account);
    }
}

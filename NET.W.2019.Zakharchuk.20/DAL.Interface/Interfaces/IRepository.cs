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
        void UpdateAccount(DalAccount account);
    }
}

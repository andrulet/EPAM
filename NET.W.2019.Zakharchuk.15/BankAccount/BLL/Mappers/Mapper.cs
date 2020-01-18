using System;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class Mapper
    {
        public static Account ToAccount(this DalAccount dalAccount)
        {
            return (Account)Activator.CreateInstance(
               GetAccountType(dalAccount.AccountType),
               dalAccount.Id,
               dalAccount.FirstName,
               dalAccount.Surname,
               dalAccount.Score,
               dalAccount.BonusPoint);
        }

        public static DalAccount ConvertToDalAccount(this Account account)
        {
            return new DalAccount
            {
                AccountType = account.GetType().Name,
                BonusPoint = account.BonusPoint,
                Score = account.Score,
                Id = account.Id,
                FirstName = account.FirstName,
                Surname = account.Surname,                
            };
        }
        private static Type GetAccountType(string type)
        {
            if (type.Contains("Gold"))
            {
                return typeof(GoldAccount);
            }

            if (type.Contains("Platinum"))
            {
                return typeof(PlatinumAccount);
            }

            return typeof(BaseAccount);
        }
    }
}

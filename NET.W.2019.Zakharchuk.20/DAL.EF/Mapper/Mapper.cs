using DAL.Interface.DTO;
using DAL.EF.Entities;

namespace DAL.EF.Mapper
{
    public static class Mapper
    {
        public static DalAccount ConvertToDaLAccount(this AccountEF account)
        {
            return new DalAccount
            {
                Id = account.Id,
                AccountType = account.AccountType,
                FirstName = account.FirstName,
                Surname = account.Surname,
                Score = account.Score,
                BonusPoint = account.BonusPoint
            };
        }

        public static AccountEF ConvertToAccountEF(this DalAccount account)
        {
            return new AccountEF
            {
                Id = account.Id,
                AccountType = account.AccountType,
                FirstName = account.FirstName,
                Surname = account.Surname,
                Score = account.Score,
                BonusPoint = account.BonusPoint
            };
        }
    }
}

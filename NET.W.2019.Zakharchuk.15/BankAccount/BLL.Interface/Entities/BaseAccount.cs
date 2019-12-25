using System;

namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        public BaseAccount(string numberScore, string firstName, string surname, decimal score) : base(numberScore, firstName, surname, score)
        {
            this.Percent = 2;
        }

        public BaseAccount(string numberScore, string firstName, string surname, decimal score, byte percent) : this(numberScore, firstName, surname, score)
        {
            this.Percent = percent;
        }

        protected override int GetBonusPointDeposit(decimal money)
        {
            return (int)((this.Score + money) / 100 * this.Percent);
        }

        protected override int GetBonusPointWithdrawal(decimal money)
        {
            return (int)((this.Score + money) / 100 * (this.Percent / 2));
        }
    }
}

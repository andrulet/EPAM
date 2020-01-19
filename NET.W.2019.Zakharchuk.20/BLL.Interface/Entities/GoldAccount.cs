using System;

namespace BLL.Interface.Entities
{
    public class GoldAccount : Account
    {
        /// <inheritdoc/>
        public GoldAccount(int id, string firstName, string surname, decimal score = 0) : base(id, firstName, surname, score)
        {
            this.Percent = 5;
        }

        /// <inheritdoc/>
        public GoldAccount(int id, string firstName, string surname, decimal score, int bonusPoint) : base(id, firstName, surname, score, bonusPoint)
        {
        }

        /// <inheritdoc/>
        protected override int GetBonusPointDeposit(decimal money)
        {
            return (int)((this.Score + money) / 100 * this.Percent);
        }

        /// <inheritdoc/>
        protected override int GetBonusPointWithdrawal(decimal money)
        {
            return (int)((this.Score + money) / 100 * (this.Percent / 2));
        }
    }
}

using System;

namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        private string _firstName;
        private string _surName;
        private string _numberScore;

        protected Account(string numberScore, string firstName, string surname, decimal score)
        {
            NumberScore = numberScore;
            FirstName = firstName;
            Surname = surname;
            Score = score;            
            BonusPoint += GetBonusPointDeposit(score);
        }

        public string NumberScore
        { 
            get => _numberScore;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Number score can't be empty");
                }

                _numberScore = value;
            } 
        }

        public string FirstName 
        { 
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First Name can't be empty");
                }

                _firstName = value;
            } 
        }

        public string Surname 
        { 
            get => _surName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Surname can't be empty");
                }

                _surName = value;
            } 
        }

        public decimal Score { get; set; }

        public int BonusPoint { get; set; }

        public byte Percent { get; set; }

        public void WithdrawalFromScore(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Withdrawal {nameof(amount)} can't be less or equally 0.");
            }

            if (amount > Score)
            {
                throw new ArgumentException($"{nameof(amount)} more than account amount.");
            }

            Score -= amount;
            BonusPoint -= GetBonusPointWithdrawal(amount);
        }

        public void DepositToScore(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Withdrawal {nameof(amount)} can't be less or equally 0.");
            }            

            Score += amount;
            BonusPoint += GetBonusPointDeposit(amount);
        }
                
        protected abstract int GetBonusPointWithdrawal(decimal money);

        protected abstract int GetBonusPointDeposit(decimal money);
    }
}

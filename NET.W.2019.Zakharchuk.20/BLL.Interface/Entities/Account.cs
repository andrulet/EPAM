using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Describes the ability to manage accounts.
    /// </summary>
    public abstract class Account
    {
        protected int _id;
        protected string _firstName;
        protected string _surName;
        protected decimal _score;
        protected int _bonusPoint;
        protected byte Percent { get; set; }

        /// <summary>
        /// Constructor for creating a new instance of <see cref="AccountType"/> class.
        /// </summary>
        /// <param name="id">Id of instance <see cref="Account"/> class.</param>
        /// <param name="firstName">Firstname of instance <see cref="Account"/> class.</param>
        /// <param name="surname">Surname of instance <see cref="Account"/> class.</param>
        /// <param name="score">Score of instance <see cref="Account"/> class.</param>
        protected Account(int id, string firstName, string surname, decimal score = 0)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.Surname = surname;
            this.Score = score;
            this.BonusPoint += GetBonusPointDeposit(score);
        }

        /// <summary>
        /// Constructor for creating a new instance of <see cref="AccountType"/> class.
        /// </summary>
        /// <param name="id">Id of instance <see cref="Account"/> class.</param>
        /// <param name="firstName">Firstname of instance <see cref="Account"/> class.</param>
        /// <param name="surname">Surname of instance <see cref="Account"/> class.</param>
        /// <param name="score">Score of instance <see cref="Account"/> class.</param>
        /// <param name="bonusPoint">Bonus point of instance <see cref="Account"/> class.</param>
        protected Account(int id, string firstName, string surname, decimal score, int bonusPoint)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.Surname = surname;
            this.Score = score;
            this.BonusPoint = bonusPoint;
        }

        /// <summary>
        /// Property for <see cref="Id"/>.
        /// </summary>
        public int Id
        { 
            get => _id;
            set
            {
                if (value < 0 || value > int.MaxValue)
                {
                    throw new ArgumentException($"{nameof(Id)} less 0 or more {int.MaxValue}.");
                }

                _id = value;
            } 
        }

        /// <summary>
        /// Property for <see cref="FirstName "/>.
        /// </summary>
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

        /// <summary>
        /// Property for <see cref="Surname"/>.
        /// </summary>
        public string Surname 
        { 
            get => _surName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(value)} can't be empty");
                }

                _surName = value;
            } 
        }

        /// <summary>
        /// Property for <see cref="Score"/>.
        /// </summary>
        public decimal Score 
        {
            get => _score;
            set
            {
                if(value <0 || value > decimal.MaxValue)
                {
                    throw new ArgumentException($"{nameof(Score)} less 0 or more {decimal.MaxValue}.");
                }

                _score = value;
            } 
        }

        /// <summary>
        /// Property for <see cref="BonusPoint"/>.
        /// </summary>
        public int BonusPoint 
        {
            get => _bonusPoint; 
            set
            {
                if (value < 0 || value > int.MaxValue)
                {
                    throw new ArgumentException($"{nameof(BonusPoint)} less 0 or more {decimal.MaxValue}.");
                }

                _bonusPoint = value;
            }
        }       

        /// <summary>
        /// Withdrawal money from Score.
        /// </summary>
        /// <param name="amount">Withdrawal sum.</param>
        public void WithdrawalFromScore(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Withdrawal {nameof(amount)} can't be less or equally 0.");
            }

            if (amount > this.Score)
            {
                throw new ArgumentException($"{nameof(amount)} more than account amount.");
            }

            this.Score -= amount;
            this.BonusPoint -= GetBonusPointWithdrawal(amount);
        }

        /// <summary>
        /// Deposit money from Score.
        /// </summary>
        /// <param name="amount">Deposit sum.</param>
        public void DepositToScore(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Withdrawal {nameof(amount)} can't be less or equally 0.");
            }

            this.Score += amount;
            this.BonusPoint += GetBonusPointDeposit(amount);
        }

        /// <summary>
        /// Calculate a bonus points when witgdrawing money.
        /// </summary>
        /// <param name="amount">Deposit sum.</param>
        protected abstract int GetBonusPointWithdrawal(decimal money);

        /// <summary>
        /// Calculate a bonus points when depositing money.
        /// </summary>
        /// <param name="amount">Withdrawal sum.</param>
        protected abstract int GetBonusPointDeposit(decimal money);

        public override string ToString()
        {
            return string.Format($"Account №{Id}\n Owner: {FirstName} {Surname} \n Amount: {Score}$  points:{BonusPoint} ");
        }
    }
}

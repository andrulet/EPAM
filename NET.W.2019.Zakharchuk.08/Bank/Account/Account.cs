using System;

namespace AccountInfo 
{
    /// <summary>
    /// This class this class describes the nature of a bank account.
    /// </summary>
    public class Account : IEquatable<Account>
    {
        /// <summary>
        /// Constructor Account.
        /// </summary>
        /// <param name="id">Customer account</param>
        /// <param name=firstName">Customer name</param>
        /// <param name="surname">Customer surname</param>
        /// <param name="amount">Customer amount</param>
        /// <param name="bonus">Customer bonus</param>
        /// <param name="status">Account status</param>
        /// <param name="type">Account type</param>
        public Account(int id, string firstName, string surname, decimal amount, int bonus, StatusAccount status, TypeAccount type)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.Surname = surname;
            this.Amount = amount;
            this.Bonus = bonus;
            this.Status = status;
            this.Type = type;
        }

        /// <summary>
        /// Gets to return number of account, sets to take number of account.
        /// </summary>
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// Gets to return first of account, sets to take first of account.
        /// </summary>
        public string FirstName
        {
            get; set;
        }

        /// <summary>
        /// Gets to return surname of account, sets to take surname of account.
        /// </summary>
        public string Surname
        {
            get; set;
        }

        /// <summary>
        /// Gets to return amount of account, sets to take amount of account.
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Gets to return bonus of account, sets to take bonus of account.
        /// </summary>
        public int Bonus
        {
            get; set;
        }

        /// <summary>
        /// Gets to return status of account, sets to take status of account.
        /// </summary>
        public StatusAccount Status
        {
            get; set;
        }

        /// <summary>
        /// Gets to return type of account, sets to take type of account.
        /// </summary>
        public TypeAccount Type
        {
            get; set;
        }

        /// <summary>
        /// Override  ToString.
        /// </summary>
        /// <returns>Account in string type.</returns>
        public override string ToString()
        {
            return $"Number of score - {this.Id}, first name - {this.FirstName}, second name - {this.Surname}, " +
                $"amount - {this.Amount}, bonus points - {this.Bonus}, status account - {this.Status}, type account = {this.Type}";
        }

        /// <summary>
        /// Override Equals.
        /// </summary>
        /// <param name="obj">Object compere with this Account.</param>
        /// <returns>True if objects are equivalent, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() == GetType())
            {
                Account account = obj as Account;
                return this.Equals(account);
            }

            return false;
        }

        /// <summary>
        /// Interface realization.
        /// </summary>
        /// <param name="other">Object to compare.</param>
        /// <returns>True if other and this equals.</returns>
        public bool Equals(Account other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return other.Id == this.Id;
        }

        /// <summary>
        /// Override GetHashCode.
        /// </summary>
        /// <returns>Integer GetHashCode.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + this.Amount.GetHashCode();
        }
    }
}

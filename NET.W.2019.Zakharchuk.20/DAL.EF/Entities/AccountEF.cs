using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Entities
{
    public class AccountEF
    {
        [Key]
        public int Id { get; set; }

        public string AccountType { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public decimal Score { get; set; }

        public int BonusPoint { get; set; }        
    }
}

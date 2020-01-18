using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalAccount
    {
        public int Id { get; set; }

        public string AccountType { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public decimal Score { get; set; }       
        
        public int BonusPoint { get; set; }
    }
}

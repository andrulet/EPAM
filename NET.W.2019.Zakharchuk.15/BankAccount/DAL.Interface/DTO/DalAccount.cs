﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalAccount
    {
        public string AccountType { get; set; }

        public string NumberScore { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Amount { get; set; }       
        
        public int BonusPoint { get; set; }
    }
}

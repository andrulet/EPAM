using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Describes the ability to create of account id.
    /// </summary>
    public class AccountGenerateId : IAccountGetId
    {
        private int idCounter;
        /// <summary>
        /// Generate id for a new instance ofa new Account.
        /// </summary>
        /// <returns>Integer of Id.</returns>
        public int GetId()
        {
            return ++idCounter;
        }
    }
}

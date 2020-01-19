using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.EF
{
    /// <summary>
    /// This class creates a database.
    /// </summary>
    public class AccoiuntStorageInitialazer : IDatabaseInitializer<AccountContext>
    {
        /// <inheritdoc/>
        public void InitializeDatabase(AccountContext context)
        {
            if (context.Database.Exists())
                context.Database.Delete();
            context.Database.Create();
        }
    }
}

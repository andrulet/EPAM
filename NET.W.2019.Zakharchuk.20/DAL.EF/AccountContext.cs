using System.Data.Entity;
using DAL.EF.Entities;

namespace DAL.EF
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("DBAccountStorage")
        {
            Database.SetInitializer<AccountContext>(new DropCreateDatabaseAlways<AccountContext>());
        }

        public DbSet<AccountEF> AccountEFs { get; set; }
        public DbSet<AccountTypeEF> AccountTypeEFs { get; set; }
    }
        
}

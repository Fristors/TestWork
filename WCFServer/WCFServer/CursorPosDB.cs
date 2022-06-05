using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WCFServer
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<CursorPos> CursorPos { get; set; }

        public ApplicationContext() : base("DefaultConnection")
        {
            //optio
            //Database.SetInitializer<ApplicationContext>(null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstDomain;

namespace EFTestConsoleDAL
{
    public class CodeFirstContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;
            Mappings.CustomerMapping.Map(modelBuilder);
            Mappings.OrderMapping.Map(modelBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirstDomain;

namespace EFTestConsoleDAL.Mappings
{
    public static class CustomerMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Address>();

            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Customer>()
                .HasKey(k => k.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnName("CustomerID");
//            modelBuilder.Entity<Customer>().Property(p => p.Id).HasColumnName("CustomerID");
            modelBuilder.Entity<Customer>().Property(p => p.Name).HasColumnName("CustomerName");

            modelBuilder.Entity<Customer>().Property(p => p.ContactAddress.City).HasColumnName("AddrCity");
            modelBuilder.Entity<Customer>().Property(p => p.ContactAddress.Country).HasColumnName("AddrCountry");
            modelBuilder.Entity<Customer>().Property(p => p.ContactAddress.Street).HasColumnName("AddrStreet");

            //modelBuilder.Entity<Customer>()
            //    .HasMany(t => t.Orders)
            //    .WithOptional()
            //    .Map(m => m.MapKey("CustomerId"));
        //    modelBuilder.Entity<Standard>().HasMany<Student>(s => s.StudentsList)
        //                .WithRequired(s => s.Standard).HasForeignKey(s => s.StdId);
            modelBuilder.Entity<Customer>().HasMany<Order>(s => s.Orders)
                .WithOptional().HasForeignKey(p => p.CustomerId).WillCascadeOnDelete(true);
        }
    }
}

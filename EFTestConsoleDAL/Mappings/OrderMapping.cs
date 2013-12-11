using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstDomain;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTestConsoleDAL.Mappings
{
    public static class OrderMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>()
                .HasKey(k => k.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnName("OrderId");
            //modelBuilder.Entity<Order>()
            //    .Property(p => p.CustomerId).HasColumnName("CustomerId");
            modelBuilder.Entity<Order>()
                .Property(p => p.OrderNo).HasColumnName("OrderNo");
            modelBuilder.Entity<Order>()
                .Property(p => p.Amount).HasColumnName("OrderAmount");

        }
    }
}

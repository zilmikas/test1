using CodeFirstDomain;
using EFTestConsoleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = null;
            using (var rep = new CustomerRepository())
            {
                var cst = new Customer
                {
                    Id = rep.GenerateId(),
                    ContactAddress = new Address()
                    {
                        City = "Wilno",
                        Country = "LT",
                        Street = "BBZ"
                    },
                    Name = "testas 2"
                };
                var ord = new Order(cst.Id, "11", 10)
                {
                    Id = rep.GenerateId()
                };
                cst.Orders.Add(ord);
                var ord1 = new Order(cst.Id, "15", 25)
                {
                    Id = rep.GenerateId()
                };
                cst.Orders.Add(ord1);
                rep.Insert(cst);
                //c1 = rep.Get(20);
                //var n2 = c1.Orders.Count;
                //rep.Delete(20);
                rep.Save();
            }
        }
    }
}

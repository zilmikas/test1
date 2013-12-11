using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstDomain;

namespace EFTestConsoleDAL
{
    public  class CustomerRepository:IRepository<Customer>
    {
        private readonly CodeFirstContext ctx;

        public CustomerRepository()
        {
            ctx=new CodeFirstContext();
        }

        public IEnumerable<Customer> ListAll()
        {
            return ctx.Customers.ToList();
        }

        public Customer Get(int entityId)
        {
            var cst= ctx.Customers.Find(entityId);
            ctx.Entry(cst).Collection(p=>p.Orders).Load();
            return cst;
        }

        public void Insert(Customer entity)
        {
            ctx.Customers.Add(entity);
        }

        public void Delete(int entityId)
        {
            var cst = ctx.Customers.Find(entityId);
            if(cst!=null)
                ctx.Customers.Remove(cst);
        }

        public void Update(Customer entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public int GenerateId()
        {
            return ctx.Database.SqlQuery<int>("select next value for entityPK").FirstOrDefault();
        }
    }
}

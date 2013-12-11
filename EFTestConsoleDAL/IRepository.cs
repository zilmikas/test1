using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstDomain;

namespace EFTestConsoleDAL
{
    public interface IRepository<T>:IDisposable
    {
        IEnumerable<T> ListAll();
        T Get(int entityId);
        void Insert(T entity);
        void Delete(int entityId);
        void Update(T entity);
        void Save();
        int GenerateId();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiBdAdo
{
    interface IRepository <T> 
    {
        void Create(T item);
        T Get(int id);
        void Update(T item);
        IQueryable<T> GetList();
        void Remove(T item);

        void Save();
    }
}

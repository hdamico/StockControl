using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlStock.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetID(int id);
        bool Add(T model);
        bool Update(T model);
        bool Del(int id);
        void save();

    }
}

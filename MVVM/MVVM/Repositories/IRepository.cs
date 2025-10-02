using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Repositories
{ 
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        SQLiteDataAdapter GetAllDataAdapter();
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}





using MVVM.Database.Queries;
using MVVM.Models;
using MVVM.Models.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVVM.Repositories
{

    public class Customers<T> : BaseRepository<T>  where T : class
    { 
        public Customers()
            {
            _SQLiteHelper = new Database.SQLiteHelper();
            }
        public override void Add(T entity)
        {
            if (entity is Customers customer)
            {
                Dictionary<string, object> parms = new Dictionary<string, object>();
                parms.Add("@Id", customer.Id);
                parms.Add("@FullName", customer.FullName);
                parms.Add("@Address", customer.Address);
                parms.Add("@Phone", customer.Phone);
                parms.Add("@NeedGoods1", customer.NeedGoods1);
                parms.Add("@NeedGoods2", customer.NeedGoods2);
                parms.Add("@NeedGoods3", customer.NeedGoods3);
        _SQLiteHelper.ExecuteNonQuery(EmployeeQueries.InsertEmployee, parms);
            }
        }
        public override void Delete(int id)
        {
            Customers employee = new Customers();
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@Id", employee.Id);
            _SQLiteHelper.ExecuteNonQuery(EmployeeQueries.DeleteEmployee, parms);
        }
        public override IEnumerable<T> GetAll()
            {
                IEnumerable<T> employees = _SQLiteHelper.ExecuteReader<T>(EmployeeQueries.GetAllEmployees, null);
                return employees;
            }
        public override SQLiteDataAdapter GetAllDataAdapter()
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(EmployeeQueries.GetAllEmployees, _SQLiteHelper.CreateConnection());
            return adapter;
        }
        public override T GetById(int id)
        {
            // Реализация поиска по ID
            throw new NotImplementedException();
        }
        public override void Save()
        {
            // Реализация сохранения изменений
            throw new NotImplementedException();
        }
        public override void Update(T entity)
        {
            // Реализация обновления
            throw new NotImplementedException();
        }
    }

}

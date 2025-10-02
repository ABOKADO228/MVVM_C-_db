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

    public class EmployeeRepos<T> : BaseRepository<T>  where T : class
    { 
        public override void Add(T entity)
        {
            if (entity is Employee employee)
            {
                Dictionary<string, object> parms = new Dictionary<string, object>();
                parms.Add("@Id", employee.Id);
                parms.Add("@FullName", employee.FullName);
                parms.Add("@Age", employee.Age);
                parms.Add("@Gender", employee.Gender);
                parms.Add("@Address", employee.Address);
                parms.Add("@Phone", employee.Phone);
                parms.Add("@Pass", employee.Pass);
                parms.Add("@PositionId", employee.PositionId);

                _SQLiteHelper.ExecuteNonQuery(EmployeeQueries.InsertEmployee, parms);
            }
        }
        public override void Delete(int id)
        {
            Employee employee = new Employee();
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

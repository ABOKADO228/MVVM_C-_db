using MVVM.Database;
using MVVM.Models.Tables;
using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly Employee _employee;
        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }

        public int Id
        {
            get => _employee.Id;
            set { _employee.Id = value; OnPropertyChanged(); }
        }

        public string FullName
        {
            get => _employee.FullName;
            set { _employee.FullName = value; OnPropertyChanged(); }
        }

        public int Age {
            get => _employee.Age;
            set { _employee.Age = value; OnPropertyChanged(); }
        }
        public int Gender {
            get => _employee.Gender;
            set {
                if (value == 1 || value == 0) {
                    _employee.Gender = value; OnPropertyChanged();
                }
            }
        }
        public string Address
        {
            get => _employee.Address;
            set { _employee.Address = value; OnPropertyChanged(); }
        }
        public string Phone
        {
            get => _employee.Phone;
            set { _employee.Phone = value; OnPropertyChanged(); }
        }
        public string Pass
        {
            get => _employee.Pass;
            set { _employee.Pass = value; OnPropertyChanged(); }
        }
        public int PositionId
        {
            get => _employee.PositionId;
            set { _employee.PositionId = value; OnPropertyChanged(); }
        }
       
    }
}

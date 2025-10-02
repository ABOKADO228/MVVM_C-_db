using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM.Database;
using MVVM.Database.Queries;
using MVVM.Models;
using MVVM.Models.Tables;
using MVVM.Repositories;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly EmployeeRepos<EmployeeViewModel> _employeeRepository;
        private readonly DatabaseInitializer _databaseInitializer;
        private readonly SQLiteHelper _sqliteHelper;

        private ObservableCollection<EmployeeViewModel> _employees;
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => _employees;
            private set => SetProperty(ref _employees, value);
        }

        private EmployeeViewModel _selectedEmployee;
        public EmployeeViewModel SelectedEmployee
        {
            get => _selectedEmployee;
            set => SetProperty(ref _selectedEmployee, value);
        }

        public MainViewModel()
        {
            _sqliteHelper = new SQLiteHelper();
            _employeeRepository =  new EmployeeRepos<EmployeeViewModel>();
            _databaseInitializer = new DatabaseInitializer(_sqliteHelper);
            _databaseInitializer.InitializeDatabase();


            Employees =  new ObservableCollection<EmployeeViewModel>( _employeeRepository.GetAll());
        }

    }
}


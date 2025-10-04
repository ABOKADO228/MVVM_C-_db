using MVVM.Database;
using MVVM.Repositories;
using MVVM.ViewModels.SubViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels.PageViewModels
{
    public class EmployeeViewModelPage : ViewModelBase
    {
        private readonly EmployeeRepos<EmployeeViewModel> _employeeRepository;
        private readonly SQLiteHelper _sqliteHelper;

        private ObservableCollection<EmployeeViewModel> _employees;
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => _employees;
            private set => SetProperty(ref _employees, value);
        }
        public EmployeeViewModelPage()
        {
            _employeeRepository = new EmployeeRepos<EmployeeViewModel>();
            _sqliteHelper = new SQLiteHelper();

            Employees = new ObservableCollection<EmployeeViewModel>(_employeeRepository.GetAll());
        }
    }
}

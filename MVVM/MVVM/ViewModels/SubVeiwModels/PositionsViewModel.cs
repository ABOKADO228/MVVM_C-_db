using MVVM.ViewModels.SubVeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Должности(Код должности, Наименование должности, Оклад, Обязанности,Требования)

namespace MVVM.ViewModels.SubViewModels
{
    public class PositionsViewModel : ViewModelBase, ITableView
    {
        private readonly PositionsViewModel _positions = new PositionsViewModel();
        public int Id {
            get => _positions.Id;
            set { _positions.Id = value; OnPropertyChanged(); }
        }
        public string FullName {
            get => _positions.FullName;
            set { _positions.FullName = value; OnPropertyChanged(); }
        }
        public decimal Salary {
            get => _positions.Salary;
            set { _positions.Salary = value; OnPropertyChanged(); }
        }
        public string Responsibilities {
            get => _positions.Responsibilities;
            set { _positions.Responsibilities = value; OnPropertyChanged(); }
        }
        public string Requirements {
            get => _positions.Requirements;
            set { _positions.Requirements = value; OnPropertyChanged(); }
        }

    }
}

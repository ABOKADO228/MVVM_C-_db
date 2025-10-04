using MVVM.Database;
using MVVM.Models.Tables;
using MVVM.ViewModels.SubVeiwModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels.SubViewModels
{
    public class CustomerViewModel : ViewModelBase, ITableView
    {
        private readonly Customers  _customer;
        public CustomerViewModel(Customers customer)
        {
            _customer = customer;
        }
        public int Id
        {
            get => _customer.Id;
            set { _customer.Id = value; OnPropertyChanged(); }
        }

        public string FullName
        {
            get => _customer.FullName;
            set { _customer.FullName = value; OnPropertyChanged(); }
        }
        public string Address
        {
            get => _customer.Address;
            set { _customer.Address = value; OnPropertyChanged(); }
        }
        public string Phone
        {
            get => _customer.Phone;
            set { _customer.Phone = value; OnPropertyChanged(); }
        }
        public int PasNeedGoods1
        {
            get => _customer.NeedGoods1;
            set { _customer.NeedGoods1 = value; OnPropertyChanged(); }
        }
        public int PasNeedGoods2
        {
            get => _customer.NeedGoods1;
            set { _customer.NeedGoods1 = value; OnPropertyChanged(); }
        }
        public int PasNeedGoods3
        {
            get => _customer.NeedGoods1;
            set { _customer.NeedGoods1 = value; OnPropertyChanged(); }
        }   
    }
}

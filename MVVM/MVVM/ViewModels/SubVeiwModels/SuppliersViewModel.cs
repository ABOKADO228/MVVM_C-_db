using MVVM.ViewModels.SubVeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Поставщики(
//Код поставщика, Наименование, Адрес, Телефон, Код
//поставляемого товара 1, Код поставляемого товара 2, Код поставляемого
//товара 3
//)
namespace MVVM.ViewModels.SubViewModels
{
    public class SuppliersViewModel : ViewModelBase, ITableView
    {
        private readonly SuppliersViewModel _suppliers = new SuppliersViewModel();
        public int Id {
            get => _suppliers.Id;
            set { _suppliers.Id = value; OnPropertyChanged(); }
        }
        public string FullName {
            get => _suppliers.FullName;
            set { _suppliers.FullName = value; OnPropertyChanged(); }
        }
        public string Address {
            get => _suppliers.Address;
            set { _suppliers.Address = value; OnPropertyChanged(); }
        }
        public string Phone {
            get => _suppliers.Phone;
            set { _suppliers.Phone = value; OnPropertyChanged(); }
        }
        public int GoodsId1 {
            get => _suppliers.GoodsId1;
            set { _suppliers.GoodsId1 = value; OnPropertyChanged(); }
        }
        public int GoodsId2 {
            get => _suppliers.GoodsId2;
            set { _suppliers.GoodsId2 = value; OnPropertyChanged(); }
        }
        public int GoodsId3 {
            get => _suppliers.GoodsId3;
            set { _suppliers.GoodsId3=value; OnPropertyChanged(); }
        }
    }
}

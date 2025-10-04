using MVVM.Models.Tables;
using MVVM.ViewModels;
using MVVM.ViewModels.SubVeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Товары(Код товара, Код типа, Производитель, Наименование, Условия хранения, Упаковка, Срок годности)

namespace MVVM.ViewModels.SubViewModels
{
    public class GoodsViewModel : ViewModelBase, ITableView
    {
        private readonly Goods _goods = new Goods();
        public int Id
        {
            get => _goods.Id;
            set { _goods.Id = value; OnPropertyChanged(); }
        }
        public string TypeId {
            get => _goods.TypeId;
            set { _goods.TypeId = value; OnPropertyChanged(); }
        }
        public string Manufacturer {  
            get=>_goods.Manufacturer;
            set { _goods.Manufacturer = value; OnPropertyChanged(); }
        }
        public string Name {
            get => _goods.Name;
            set { _goods.Name = value; OnPropertyChanged(); }
        }
        public string StorageConditions {
            get => _goods.StorageConditions;
            set { _goods.StorageConditions = value; OnPropertyChanged(); }
        }
        public string Package {
            get => _goods.Package;
            set { _goods.Package = value; OnPropertyChanged(); }
        }
        public DateTime ExpirationDate {
            get => _goods.ExpirationDate;
            set { _goods.ExpirationDate = value; OnPropertyChanged();
            }
        }

        public string FullName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

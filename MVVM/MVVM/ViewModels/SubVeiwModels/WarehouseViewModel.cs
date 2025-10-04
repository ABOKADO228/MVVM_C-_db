using MVVM.Models.Tables;
using MVVM.ViewModels.SubVeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//7) Склад(Дата поступления, Дата заказа, Дата отправки, Код товара, Код
//поставщика, Код заказчика, Способ доставки, Объём, Цена, Код сотрудника)
//Запросы:
namespace MVVM.ViewModels.SubViewModels
{
    public class WarehouseViewModel : ViewModelBase, ITableView
    {
        public WarehouseViewModel _warehouse = new WarehouseViewModel();
        public DateTime ReceiptDate
        {
            get => _warehouse.ReceiptDate;
            set { _warehouse.ReceiptDate = value; OnPropertyChanged(); }
        }
        public DateTime OrderDate
        {
            get => _warehouse.OrderDate;
            set { _warehouse.OrderDate = value; OnPropertyChanged(); }
        }
        public DateTime DispatchDate
        {
            get => _warehouse.DispatchDate;
            set { _warehouse.DispatchDate = value; OnPropertyChanged(); }
        }
        public int GoodsId
        {
            get => _warehouse.GoodsId;
            set { _warehouse.GoodsId = value; OnPropertyChanged(); }
        }
        public int CustomerId
        {
            get => _warehouse.CustomerId;
            set { _warehouse.CustomerId = value; OnPropertyChanged(); }
        }
        public int SuppliersId {
            get => _warehouse.SuppliersId;
            set { _warehouse.SuppliersId = value;OnPropertyChanged(); }
        }
        public string DeliveryMethod {
            get => _warehouse.DeliveryMethod;
            set { _warehouse.DeliveryMethod = value; OnPropertyChanged(); }
        }
        public int Volume {
            get => _warehouse.Volume;
            set { _warehouse.Volume = value; OnPropertyChanged(); }
        }
        public int Price {
            get => _warehouse.Price;
            set { _warehouse.Price = value; OnPropertyChanged(); }
        }
        public int EmployeeId {
            get => _warehouse.EmployeeId;
            set { _warehouse.EmployeeId = value; OnPropertyChanged(); }
        }

        public string FullName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

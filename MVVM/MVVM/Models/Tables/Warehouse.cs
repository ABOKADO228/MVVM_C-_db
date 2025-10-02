using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//7) Склад(Дата поступления, Дата заказа, Дата отправки, Код товара, Код
//поставщика, Код заказчика, Способ доставки, Объём, Цена, Код сотрудника)
//Запросы:
namespace MVVM.Models.Tables
{
    public class Warehouse : ITable
    {
        public DateTime ReceiptDate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DispatchDate { get; set; }
        public int GoodsId { get; set; }
        public int CustomerId { get; set; }
        public int SuppliersId { get; set; }
        public string DeliveryMethod { get; set; }
        public int Volume {  get; set; }
        public int Price { get; set; }
        public int EmployeeId { get; set; }

    }
}

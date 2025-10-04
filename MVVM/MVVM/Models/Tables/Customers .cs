using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Заказчики(Код заказчика, Наименование, Адрес, Телефон, Код
//потребляемого товара 1, Код потребляемого товара 2, Код потребляемого
//товара 3)

namespace MVVM.Models.Tables
{
    public class Customers : ITable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int NeedGoods1 { get; set; }
        public int NeedGoods2 { get; set; }
        public int NeedGoods3 { get; set; }
    }
}

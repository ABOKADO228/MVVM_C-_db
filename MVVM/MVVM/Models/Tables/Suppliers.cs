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
namespace MVVM.Models.Tables
{
    public class Suppliers : ITable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int GoodsId1 {get; set;}
        public int GoodsId2 { get; set; }
        public int GoodsId3 { get; set; }
    }
}

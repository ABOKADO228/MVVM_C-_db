using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Товары(Код товара, Код типа, Производитель, Наименование, Условия хранения, Упаковка, Срок годности)

namespace MVVM.Models.Tables
{
    public class Goods : ITable
    {
        public int GoodsId { get; set; }
        public string TypeId { get; set; }
        public string Manufacturer {  get; set; }
        public string Name { get; set; }
        public string StorageConditions {  get; set; }
        public string Package { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}

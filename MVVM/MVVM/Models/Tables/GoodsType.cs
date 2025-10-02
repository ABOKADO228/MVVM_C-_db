using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Типы товаров(Код типа, Наименование, Описание, Особенности)

namespace MVVM.Models.Tables
{
    public class GoodsType : ITable
    {
        public int Id {  get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Peculiarities { get; set; }
    }
}

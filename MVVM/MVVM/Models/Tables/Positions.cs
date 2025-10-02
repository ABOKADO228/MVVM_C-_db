using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Должности(Код должности, Наименование должности, Оклад, Обязанности,Требования)

namespace MVVM.Models.Tables
{
    public class Positions : ITable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }

    }
}

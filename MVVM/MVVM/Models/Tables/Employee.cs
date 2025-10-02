using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Сотрудники(Код сотрудника, ФИО, Возраст, Пол, Адрес, Телефон,Паспортные данные, Код должности).

namespace MVVM.Models.Tables
{
    public class Employee : ITable
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Pass { get; set; }
        public int PositionId { get; set; }
    }

}

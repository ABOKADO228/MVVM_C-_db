using MVVM.Models.Tables;
using MVVM.ViewModels.SubVeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Типы товаров(Код типа, Наименование, Описание, Особенности)

namespace MVVM.ViewModels.SubViewModels
{
    public class GoodsTypeViewModel : ViewModelBase, ITableView
    {
        private readonly GoodsTypeViewModel _goodsType = new GoodsTypeViewModel();
        public int Id { 
            get => _goodsType.Id;
            set { _goodsType.Id = value; OnPropertyChanged(); }
        }
        public string FullName
        {
            get => _goodsType.FullName;
            set { _goodsType.FullName = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get => _goodsType.Description;
            set { _goodsType.Description = value; OnPropertyChanged(); }
        }
        public string Peculiarities
        {
            get => _goodsType.Peculiarities;
            set { _goodsType.Peculiarities = value; OnPropertyChanged(); }
        }
    }
}

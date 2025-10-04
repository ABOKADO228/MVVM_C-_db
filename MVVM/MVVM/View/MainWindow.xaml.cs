using MVVM.ViewModels.NavigationService;
using MVVM.ViewModels.PageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly INavigationService _navigationService;

        // Этот конструктор теперь будет вызываться через DI контейнер
        public MainWindow()
        {
            _navigationService = new ViewModels.NavigationService.NavigationService();
            InitializeComponent();

            // Устанавливаем Frame для навигации
            _navigationService.SetFrame(Employee);

            // Навигация на стартовую страницу
            _navigationService.NavigateTo<Employee>();
        }
    }
}


//Задание №15: БД Оптового склада.
//Таблицы: 1) Сотрудники(Код сотрудника, ФИО, Возраст, Пол, Адрес, Телефон,
//Паспортные данные, Код должности).
//2) Должности(Код должности, Наименование должности, Оклад, Обязанности,
//Требования)
//3) Товары(Код товара, Код типа, Производитель, Наименование, Условия
//хранения, Упаковка, Срок годности)
//4) Типы товаров(Код типа, Наименование, Описание, Особенности)
//5) Поставщики(Код поставщика, Наименование, Адрес, Телефон, Код
//поставляемого товара 1, Код поставляемого товара 2, Код поставляемого
//товара 3)
//6) Заказчики(Код заказчика, Наименование, Адрес, Телефон, Код
//потребляемого товара 1, Код потребляемого товара 2, Код потребляемого
//товара 3)
//7) Склад(Дата поступления, Дата заказа, Дата отправки, Код товара, Код
//поставщика, Код заказчика, Способ доставки, Объём, Цена, Код сотрудника)
//Запросы:
//1)	Отобразить товары отдельных поставщиков;
//2)	Отобразить товары по определенному способу доставки.

using MVVM.Database;
using MVVM.Database.Queries;
using MVVM.Models;
using MVVM.Models.Tables;
using MVVM.Repositories;
using MVVM.ViewModels.NavigationService;
using MVVM.ViewModels.PageViewModels;
using MVVM.ViewModels.SubVeiwModels;
using MVVM.ViewModels.SubViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Navigation;


namespace MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly DatabaseInitializer _databaseInitializer;
        private readonly INavigationService _navigationService;

        private readonly SQLiteHelper _sqliteHelper;

        private ObservableCollection<EmployeeViewModel> _employees;
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => _employees;
            private set => SetProperty(ref _employees, value);
        }

        private ObservableCollection<CustomerViewModel> _customers;
        public ObservableCollection<CustomerViewModel> Customers
        {
            get => _customers;
            private set => SetProperty(ref _customers, value);
        }

        private ObservableCollection<GoodsViewModel> _goods;
        public ObservableCollection<GoodsViewModel> Goods
        {
            get=>_goods;
            set=>SetProperty(ref _goods, value);
        }

        private ObservableCollection<GoodsTypeViewModel> _goodsType;
        public ObservableCollection<GoodsTypeViewModel> GoodsType
        {
            get=> _goodsType;
            set=>SetProperty(ref _goodsType, value);
        }

        private ObservableCollection<PositionsViewModel> _positions;
        public ObservableCollection<PositionsViewModel> Positions
        {
            get=> _positions;
            set=>SetProperty(ref _positions, value);
        }

        private ObservableCollection<SuppliersViewModel> _suppliers;
        public ObservableCollection<SuppliersViewModel> Suppliers
        {
            get=> _suppliers;
            set=>SetProperty(ref _suppliers, value);
        }

        private ObservableCollection<WarehouseViewModel> _warehouse;
        public ObservableCollection<WarehouseViewModel> Warehouse
        {
            get=>_warehouse; 
            set => SetProperty(ref _warehouse, value);
        }

        private ObservableCollection<ITableView> _selectedBase;
        public ObservableCollection<ITableView> SelectedBase
        {
            get => _selectedBase;
            set => SetProperty(ref _selectedBase, value);
        }

        private ObservableCollection<string> _tables;
        public ObservableCollection<string> Tables {
            get => _tables;
            private set => SetProperty(ref _tables, value); 
        }
        private string _selectedTable;
        public string SelectedTable
        {
            get => _selectedTable;
            set { SetProperty(ref _selectedTable, value);}
        }
        public MainViewModel()
        {
            _sqliteHelper = new SQLiteHelper();
            _databaseInitializer = new DatabaseInitializer(_sqliteHelper);
            _databaseInitializer.InitializeDatabase();
            Tables = _sqliteHelper.GetAllTables();
            _navigationService = new NavigationService.NavigationService();
            EmployeeViewModelPage employeeViewModelPage = new EmployeeViewModelPage();

            NavigateToPage1Command = new RelayCommand(() => _navigationService.NavigateTo<View.Employee>());
            //NavigateToPage2Command = new RelayCommand(() => _navigationService.NavigateTo<Page2>());
            GoBackCommand = new RelayCommand(() => _navigationService.GoBack(),
                                            () => _navigationService.CanGoBack);
        }

        public ICommand NavigateToPage1Command { get; }
        public ICommand NavigateToPage2Command { get; }
        public ICommand GoBackCommand { get; }


    }
}


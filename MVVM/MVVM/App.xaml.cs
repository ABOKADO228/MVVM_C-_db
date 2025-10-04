using Microsoft.Extensions.DependencyInjection;
using MVVM.View;
using MVVM.ViewModels;
using MVVM.ViewModels.NavigationService;
using MVVM.ViewModels.NavigationService.Interfaces;
using MVVM.ViewModels.PageViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ViewTypeLocator.Register<HomeViewModel, HomePage>();
            ViewTypeLocator.Register<ProductsViewModel, ProductsPage>();
            ViewTypeLocator.Register<SettingsViewModel, SettingsPage>();
            ViewTypeLocator.Register<ProfileViewModel, ProfilePage>();
            ViewTypeLocator.Register<DashboardViewModel, DashboardPage>();
            ViewTypeLocator.Register<AnalyticsViewModel, AnalyticsPage>();

            // Создание главного окна
            var mainWindow = new MainWindow();

            // Создание NavigationService
            var navigationService = new MultiFrameNavigationService(CreateViewModel);

            // Создание MainViewModel
            var mainViewModel = new MainViewModel(navigationService);
            mainWindow.DataContext = mainViewModel;

            // Регистрация фреймов
            navigationService.RegisterFrame("LeftFrame", mainWindow.LeftFrame);
            navigationService.RegisterFrame("RightFrame", mainWindow.RightFrame);
            navigationService.RegisterFrame("BottomFrame", mainWindow.BottomFrame);

            // Начальная навигация
            navigationService.NavigateTo<HomeViewModel>("LeftFrame");
            navigationService.NavigateTo<SettingsViewModel>("RightFrame");
            navigationService.NavigateTo<DashboardViewModel>("BottomFrame");

            mainWindow.Show();
        }
    }
}

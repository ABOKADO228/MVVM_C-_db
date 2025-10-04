using System;


namespace MVVM.ViewModels.NavigationService.Interfaces
{

    public interface INavigationAware
    {
        void OnNavigatedTo(object parameter);
        void OnNavigatedFrom();
    }
}

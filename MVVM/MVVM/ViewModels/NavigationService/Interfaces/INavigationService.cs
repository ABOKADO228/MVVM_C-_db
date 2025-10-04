using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVM.ViewModels.NavigationService
{
    public interface INavigationService
    {
        bool CanGoBack(string frameName);
        void NavigateTo<T>(string frameName) where T : ViewModelBase;
        void NavigateTo<T>(string frameName, object parameter) where T : ViewModelBase;
        void GoBack(string frameName);
        void ClearHistory(string frameName);
        void RegisterFrame(string frameName, Frame frame);
        void UnregisterFrame(string frameName);
    }
}

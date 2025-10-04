using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MVVM.ViewModels.NavigationService
{
    using MVVM.ViewModels.NavigationService.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    public class MultiFrameNavigationService : INavigationService
    {
        private readonly Dictionary<string, Frame> _frames = new Dictionary<string, Frame>();
        private readonly Func<Type, ViewModelBase> _viewModelFactory;

        public MultiFrameNavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void RegisterFrame(string frameName, Frame frame)
        {
            if (_frames.ContainsKey(frameName))
            {
                throw new InvalidOperationException($"Frame '{frameName}' already registered");
            }

            _frames[frameName] = frame;
            frame.Navigated += OnNavigated;
        }

        public void UnregisterFrame(string frameName)
        {
            if (_frames.TryGetValue(frameName, out Frame frame))
            {
                frame.Navigated -= OnNavigated;
                _frames.Remove(frameName);
            }
        }

        public bool CanGoBack(string frameName)
        {
            return _frames.TryGetValue(frameName, out Frame frame) && frame.CanGoBack;
        }

        public void NavigateTo<T>(string frameName) where T : ViewModelBase
        {
            NavigateTo<T>(frameName, null);
        }

        public void NavigateTo<T>(string frameName, object parameter) where T : ViewModelBase
        {
            if (!_frames.TryGetValue(frameName, out Frame frame))
            {
                throw new InvalidOperationException($"Frame '{frameName}' not registered");
            }

            var viewModel = _viewModelFactory(typeof(T));
            var page = CreatePageForViewModel(viewModel);

            // Передаем параметр во ViewModel, если она реализует INavigationAware
            if (parameter != null && viewModel is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedTo(parameter);
            }

            frame.Navigate(page, parameter);
        }

        public void GoBack(string frameName)
        {
            if (_frames.TryGetValue(frameName, out Frame frame) && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        public void ClearHistory(string frameName)
        {
            if (_frames.TryGetValue(frameName, out Frame frame))
            {
                while (frame.CanGoBack)
                {
                    frame.RemoveBackEntry();
                }
            }
        }

        private Page CreatePageForViewModel(ViewModelBase viewModel)
        {
            var pageType = ViewTypeLocator.GetViewTypeForViewModel(viewModel.GetType());
            var page = (Page)Activator.CreateInstance(pageType);
            page.DataContext = viewModel;
            return page;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            // Уведомляем ViewModel о навигации, если она реализует INavigationAware
            if (e.Content is Page page && page.DataContext is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedFrom();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Controls;


namespace MVVM.ViewModels.NavigationService.Interfaces
{

    public static class ViewTypeLocator
    {
        private static readonly Dictionary<Type, Type> _viewModelToViewMapping = new Dictionary<Type, Type>();

        public static void Register<TViewModel, TView>()
            where TViewModel : ViewModelBase
            where TView : Page
        {
            _viewModelToViewMapping[typeof(TViewModel)] = typeof(TView);
        }

        public static Type GetViewTypeForViewModel(Type viewModelType)
        {
            if (_viewModelToViewMapping.TryGetValue(viewModelType, out Type viewType))
            {
                return viewType;
            }

            // Для отладки можно временно вернуть заглушку
            throw new InvalidOperationException($"No view registered for ViewModel: {viewModelType.Name}");
        }
    }
}

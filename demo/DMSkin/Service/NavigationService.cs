using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.Service
{
    public class NavigationService : ViewModelBase, INavigationService
    {
        private readonly Dictionary<string, Uri> _pagesByKey;
        private readonly List<string> _historic;
        private string _currentPageKey;

        #region Properties
        public string CurrentPageKey
        {
            get
            {
                return _currentPageKey;
            }

            private set
            {
                Set(() => CurrentPageKey, ref _currentPageKey, value);
            }
        }
        public object Parameter { get; private set; }
        #endregion

        #region Ctors and Methods
        public NavigationService()
        {
            _pagesByKey = new Dictionary<string, Uri>();
            _historic = new List<string>();
        }
        public void GoBack()
        {
            if (_historic.Count > 1)
            {
                _historic.RemoveAt(_historic.Count - 1);

                NavigateTo(_historic.Last(), "Back");
            }
        }
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, "Next");
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                }

                if (GetDescendantFromName(Application.Current.MainWindow, "MainFrame") is Frame frame)
                {
                    frame.Source = _pagesByKey[pageKey];
                }
                Parameter = parameter;
                if (parameter.ToString().Equals("Next"))
                {
                    _historic.Add(pageKey);
                }
                CurrentPageKey = pageKey;
            }
        }

        public void Configure(string key, Uri pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = pageType;
                }
                else
                {
                    _pagesByKey.Add(key, pageType);
                }
            }
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            if (count < 1)
            {
                return null;
            }
            for (var i = 0; i < count; i++)
            {
                if (VisualTreeHelper.GetChild(parent, i) is FrameworkElement frameworkElement)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}

using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using System.Windows;

namespace DMSkin
{
    public partial class FrameWindow
    {
        public FrameWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo("login");
        }
    }
}

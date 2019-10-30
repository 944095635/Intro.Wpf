using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace DMSkin.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        /// <summary>
        /// 命令Command
        /// </summary>
        public ICommand EntryCommand => new RelayCommand(() =>
        {
            ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo("main");
        });
    }
}

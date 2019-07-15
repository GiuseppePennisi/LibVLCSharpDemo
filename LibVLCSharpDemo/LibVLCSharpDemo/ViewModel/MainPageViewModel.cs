
using LibVLCSharpDemo.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibVLCSharpDemo.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand OpenPopupCommand { protected set; get; }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            OpenPopupCommand = new Command(async () => await navigationService.NavigateAsync(Locator.PopupVideoPage));
        }
    }
}

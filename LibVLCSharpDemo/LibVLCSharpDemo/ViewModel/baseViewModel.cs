using LibVLCSharpDemo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LibVLCSharpDemo.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigationService navigationService { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel(INavigationService navigationService)
        {
            navigationService = navigationService ?? throw new ArgumentNullException("navigationService");
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

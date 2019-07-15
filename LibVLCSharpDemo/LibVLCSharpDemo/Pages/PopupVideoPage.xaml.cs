using GalaSoft.MvvmLight.Messaging;
using LibVLCSharpDemo.Utils;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibVLCSharpDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupVideoPage : PopupPage
    {
        public PopupVideoPage()
        {
            var vm = App.Locator.PopupVideoVM;
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Messenger.Default.Send(new OnApperingVideoMessage());
        }

        private void VideoViewMediaPlayerChanged(object sender, LibVLCSharp.Shared.MediaPlayerChangedEventArgs e)
        {
            Messenger.Default.Send(new OnVideoViewInitializedMessage());
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }
    }
}
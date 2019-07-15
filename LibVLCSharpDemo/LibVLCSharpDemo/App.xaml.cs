using GalaSoft.MvvmLight.Ioc;
using LibVLCSharpDemo.Pages;
using LibVLCSharpDemo.Utils;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibVLCSharpDemo
{
    public partial class App : Application
    {
        private static Locator _locator;
        public static Locator Locator { get { return _locator ?? (_locator = Locator.Instance); } }
        public App()
        {
            InitializeComponent();
            INavigationService navigationService;
            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                navigationService = new NavigationServiceImpl();

                navigationService.Configure(Locator.MainPage, typeof(MainPage));
                navigationService.Configure(Locator.PopupVideoPage, typeof(PopupVideoPage));
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            }

            else
            {
                navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            }

            var mainpage = (navigationService).SetRootPage(Locator.MainPage);
            MainPage = mainpage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

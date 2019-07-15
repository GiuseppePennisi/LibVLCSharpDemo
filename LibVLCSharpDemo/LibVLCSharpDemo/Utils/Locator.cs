using GalaSoft.MvvmLight.Ioc;
using LibVLCSharpDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibVLCSharpDemo.Utils
{
    public sealed class Locator
    {

        private static readonly Locator instance = new Locator();



        static Locator()
        {
        }

        public static Locator Instance
        {
            get
            {
                return instance;
            }

        }

        private Locator()
        {

            SimpleIoc.Default.Register<PopupViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();

        }

        #region Constants Pages' names


        public const string PopupVideoPage = "PopupVideoPage";
        public const string MainPage = "MainPage";

        #endregion



        public PopupViewModel PopupVideoVM
        {
            get
            {
                return SimpleIoc.Default.GetInstance<PopupViewModel>();
            }
        }

        public MainPageViewModel MainPageVM
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainPageViewModel>();
            }
        }

    }
}
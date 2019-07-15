using GalaSoft.MvvmLight.Messaging;
using LibVLCSharp.Shared;
using LibVLCSharpDemo.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibVLCSharpDemo.ViewModel
{
    public class PopupViewModel : BaseViewModel
    {
        private LibVLC LibVLC { get; set; }

        private bool IsLoaded { get; set; }
        private bool IsVideoViewInitialized { get; set; }

        private MediaPlayer _mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get { return _mediaPlayer; }
            set
            {
                _mediaPlayer = value;
                OnPropertyChanged();
            }
        }
        public PopupViewModel(INavigationService navigationService) : base(navigationService)
        {
            
            Messenger.Default.Register<OnApperingVideoMessage>(this, OnAppearing);
            Messenger.Default.Register<OnVideoViewInitializedMessage>(this, OnVideoViewInitialized);
            Task.Run(Initialize);
        }

        private void Initialize()
        {
            Core.Initialize();

            LibVLC = new LibVLC();
            MediaPlayer = new MediaPlayer(LibVLC)
            {
                Media = new Media(LibVLC,
                     "https://download.blender.org/peach/bigbuckbunny_movies/BigBuckBunny_320x180.mp4",
                     FromType.FromLocation)
            };

        }

        public void OnAppearing(OnApperingVideoMessage msg)
        {
            IsLoaded = true;
            Play();

        }

        public void OnVideoViewInitialized(OnVideoViewInitializedMessage msg)
        {
            IsVideoViewInitialized = true;
            Play();
        }

        private void Play()
        {
            if (IsLoaded && IsVideoViewInitialized)
            {
                MediaPlayer.Play();
            }
        }
    }
}

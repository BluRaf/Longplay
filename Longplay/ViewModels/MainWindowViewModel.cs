using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using Avalonia;
using ReactiveUI;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Parsers.Nodes;
using ManagedBass;
using ManagedBass.DirectX8;

namespace Longplay.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        public MusicEngine Player { get; } = new MusicEngine();
        #endregion
        
        
        public MainWindowViewModel()
        {
            OpenTrackCommand = ReactiveCommand.Create<object>(OpenTrack);
            //TranscodeTrackCommand = ReactiveCommand.Create<object>(TranscodeTrack);
            StopTrackCommand = ReactiveCommand.Create<object>(StopTrack);
            PlayPauseTrackCommand = ReactiveCommand.Create<object>(PlayPauseTrack);
            // PreviousTrackCommand = ReactiveCommand.Create<object>(PreviousTrack);
            // NextTrackCommand = ReactiveCommand.Create<object>(NextTrack);
        }

        #region Commands
        public ReactiveCommand<object, System.Reactive.Unit> OpenTrackCommand { get; }
        //public ReactiveCommand<object, System.Reactive.Unit> TranscodeTrackCommand { get; }
        public ReactiveCommand<object, System.Reactive.Unit> StopTrackCommand { get; }
        public ReactiveCommand<object, System.Reactive.Unit> PlayPauseTrackCommand { get; }
        // public ReactiveCommand<object, System.Reactive.Unit> PreviousTrackCommand { get; }
        // public ReactiveCommand<object, System.Reactive.Unit> NextTrackCommand { get; }
        #endregion
        
        private async void OpenTrack(object o)
        {
            string[]? result = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = "All files", Extensions =  { "*" } });
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                 result = await dialog.ShowAsync(desktop.MainWindow);
            }

            if (result != null)
            {
                await Player.LoadAsync(result[0]);
                Duration = Player.Duration;
                Ready = true;
            }
        }
        
        private void StopTrack(object o)
        {
            if (!Ready)
                return;

            if (Player.State == PlaybackState.Playing)
            {
                if (!Player.Stop())
                    return;
            }
        }
        
        private void PlayPauseTrack(object o)
        {
            if (!Ready)
                return;

            if (Player.State == PlaybackState.Playing)
            {
                if (!Player.Pause())
                    return;
            }
            else
            {
                // if (Position == 0)
                //      Position = Player.Duration.TotalSeconds;

                if (!Player.Play())
                    return;
            }
        }
        // private void PreviousTrack(object o)
        // {
        //     Console.WriteLine("Previous/Rewind");
        // }
        // private void NextTrack(object o)
        // {
        //     Console.WriteLine("Next");
        // }


        #region Properties
        public bool Ready { get; set; }

        private TimeSpan _position = TimeSpan.Zero;
        public TimeSpan PositionRefresh
        {
            get => _position;
            set
            {
                _position = value;
                this.RaisePropertyChanged("Position");
            }
        }

        public TimeSpan Position
        {
            get => _position;
            set
            {
                Player.Position = value;
                this.RaisePropertyChanged("PositionRefresh");
            }
        }

        private TimeSpan _duration = TimeSpan.Zero;
        public TimeSpan Duration
        {
            get => _duration;
            set => this.RaiseAndSetIfChanged(ref _duration, value);
        }

        public double Volume
        {
            get => Player.Volume;
            set => Player.Volume = value;
        }
        #endregion
    }
}
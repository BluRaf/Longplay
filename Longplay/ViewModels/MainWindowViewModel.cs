using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace Longplay.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        
        public MainWindowViewModel()
        {
            PlayPauseTrackCommand = ReactiveCommand.Create<object>(PlayPauseTrack);
            PreviousTrackCommand = ReactiveCommand.Create<object>(PreviousTrack);
            NextTrackCommand = ReactiveCommand.Create<object>(NextTrack);
        }

        public ReactiveCommand<object, System.Reactive.Unit> PlayPauseTrackCommand { get; }
        public ReactiveCommand<object, System.Reactive.Unit> PreviousTrackCommand { get; }
        public ReactiveCommand<object, System.Reactive.Unit> NextTrackCommand { get; }

        private void PlayPauseTrack(object o)
        {
            Console.WriteLine("Play/Pause");
        }
        private void PreviousTrack(object o)
        {
            Console.WriteLine("Previous/Rewind");
        }
        private void NextTrack(object o)
        {
            Console.WriteLine("Next");
        }
    }
}
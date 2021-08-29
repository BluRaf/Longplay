using System;
using System.Threading.Tasks;
using System.Timers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Parsers.Nodes;
using Avalonia.Platform;
using Avalonia.Markup.Xaml;
using Avalonia.Rendering;
using Avalonia.Threading;
using Longplay.ViewModels;
using ReactiveUI;

namespace Longplay.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel? ViewModel => (MainWindowViewModel)DataContext!;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            var clockTimer = new Timer(100.0);
            clockTimer.Elapsed += Timer_Elapsed;
            clockTimer.AutoReset = true;
            clockTimer.Start();
            Closed += (object sender, EventArgs e) => { clockTimer.Elapsed -= Timer_Elapsed; };

#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            Dispatcher.UIThread.InvokeAsync((Action) delegate()
            {
                if (ViewModel != null) ViewModel.PositionRefresh = ViewModel.Player.Position;
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
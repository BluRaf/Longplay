using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Longplay.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;


namespace Longplay.Views
{
    public class OpenUrlDialog : ReactiveWindow<OpenUrlDialogViewModel>
    {
        public OpenUrlDialog()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d => d(ViewModel!.OpenUrlCommand.Subscribe(Close)));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
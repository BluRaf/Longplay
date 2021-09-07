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
    public class OpenUrlDialogViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, string?> OpenUrlCommand { get; }
        
        public OpenUrlDialogViewModel()
        {
            OpenUrlCommand = ReactiveCommand.Create(() =>
            {
                return UrlToOpen;
            });
        }
        private string _urlToOpen = "";
        public string? UrlToOpen
        {
            get => _urlToOpen;
            set => this.RaiseAndSetIfChanged(ref _urlToOpen, value);
        }
    }
}
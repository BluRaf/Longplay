﻿using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Projektanker.Icons.Avalonia;
using Projektanker.Icons.Avalonia.FontAwesome;

namespace Longplay
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .AfterSetup(AfterSetupCallback)
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
        
        // Called after setup
        private static void AfterSetupCallback(AppBuilder appBuilder)
        {
            // Register icon provider(s)
            IconProvider.Register<FontAwesomeIconProvider>();
        }
    }
}
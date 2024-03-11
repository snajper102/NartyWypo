using Avalonia;
using Avalonia.ReactiveUI;
using System;
using NartyWypo.ViewModels;

namespace NartyWypo;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var app = BuildAvaloniaApp();
        var mainWindowViewModel = new MainWindowViewModel();
        mainWindowViewModel.DisplayDataFromSQLite(); // Dodajemy wywołanie metody

        app.StartWithClassicDesktopLifetime(args);
    }
    
    

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();


}

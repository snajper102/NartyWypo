using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using NartyWypo.ViewModels;
using ReactiveUI;

namespace NartyWypo.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    
#if DEBUG
    this.AttachDevTools();
#endif

        this.WhenActivated(d => d(ViewModel.ShowDialog.RegisterHandler(DoShowDialogAsync)));





}

private async Task DoShowDialogAsync(InteractionContext<MainWindowViewModel, DataFormViewModel?> interaction)
    {
        var dialog = new DataFormView();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<DataFormViewModel?>(this);
        interaction.SetOutput(result);
    }


private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // Ta metoda zostanie wywołana po kliknięciu przycisku
        Console.WriteLine("Dzień dobry!");

        
    }

}
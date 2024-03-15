using System;
using System.Data.SQLite;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NartyWypo.ViewModels;
using NartyWypo.Views;
using ReactiveUI;

namespace NartyWypo.ViewModels
{
    

public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ShowDialog = new Interaction<MainWindowViewModel, DataFormViewModel?>();
            
            BuyMusicCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new MainWindowViewModel();

                var result = await ShowDialog.Handle(store);

                
            });
            
        
            
            
        }
        
        
#pragma warning disable CA1822 // Mark members as static
        public string Greeting => "Welcome to Avalonia!";
        public ICommand BuyMusicCommand { get; }
        
#pragma warning restore CA1822 // Mark members as static
        public Interaction<MainWindowViewModel, DataFormViewModel?> ShowDialog { get; }
        
       
        public void DisplayDataFromSQLite()
        {
            string connectionString = "Data Source=NartyWypo.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT id, imie, nazwisko FROM Osoby";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string imie = reader.GetString(1);
                            string nazwisko = reader.GetString(2);

                            Console.WriteLine($"ID: {id}, Imię: {imie}, Nazwisko: {nazwisko}");
                        }
                    }
                }
            }
        }
    }


}
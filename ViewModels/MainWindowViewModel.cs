using System;
using System.Data.SQLite;

namespace NartyWypo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

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

        public static void Main1(string[] args)
        {
            
        }
    }
}
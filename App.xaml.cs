using System;
using Proiect_Telefon.Data;
using System.IO;

namespace Proiect_Telefon
{
    public partial class App : Application
    {
        static ShoppingCartDatabase database;
        public static ShoppingCartDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   ShoppingCartDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "ShoppingCart.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
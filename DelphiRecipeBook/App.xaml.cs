using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace DelphiRecipeBook
{
    public partial class App : Application
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                    Database(Path.Combine(Environment.GetFolderPath(Environment
                    .SpecialFolder.LocalApplicationData), "recipes.db3"));

                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

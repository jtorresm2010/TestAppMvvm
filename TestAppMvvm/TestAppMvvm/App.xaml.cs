using System;
using System.IO;
using TestAppMvvm.Services;
using TestAppMvvm.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestAppMvvm
{
    public partial class App : Application
    {
        static DBService database;
        public static DBService Database
        {
            get
            {
                if (database == null)
                {
                    String dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db3");
                    database = new DBService(dbPath);


                }
                return database;
            }
        }

        public static NavigationPage Navigator { get; internal set; }

        public App()
        {
            InitializeComponent();
            //MainPage = new AccordionRepeaterView();
            MainPage = new NavigationPage(new AccordionRepeaterView());
            //MainPage = new LoginView();

            
        } 

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

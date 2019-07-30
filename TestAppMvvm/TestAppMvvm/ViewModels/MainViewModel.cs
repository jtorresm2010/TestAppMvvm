using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestAppMvvm.Models;

namespace TestAppMvvm.ViewModels
{
    class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public MainViewViewModel MainView { get; set; }

        public void NewMainView()
        {
            this.MainView = new MainViewViewModel();
        }

        public MainViewModel()
        {


            initializeDB("test", "test");
            initializeDB("test5", "test5");
            initializeDB("test33", "test");
            initializeDB("test1", "test");
            initializeDB("test2", "test");
            initializeDB("test3", "test");
            initializeDB("test4", "test");
            initializeDB("test5", "test");
            initializeDB("test58", "test");
            initializeDB("test13", "test");
            initializeDB("test12", "test");
            initializeDB("test11", "test");
            initializeDB("test", "test");
            initializeDB("test6", "test");
            initializeDB("test7", "test");
            initializeDB("test8", "test");


            instance = this;

            this.Login = new LoginViewModel();

        }


        private async void initializeDB(String usuario, String pass)/* Guarda un nuevo usuario de prueba, solo si no se repite el nombre */
        {

            if (App.Database.CountUserAsync(usuario).Equals(0))
            {
                var usr = new Usuario();
                usr.NOMBRE_USUARIO = usuario;
                usr.CLAVE = pass;
                await App.Database.SaveUserAsync(usr);

            }

        }



        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return instance;
        }




    }
}

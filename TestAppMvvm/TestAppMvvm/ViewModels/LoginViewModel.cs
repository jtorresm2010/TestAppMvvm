namespace TestAppMvvm.ViewModels
{
    using System;
    using System.Windows.Input;
    using System.Diagnostics;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;
    using Models;
    using Views;

    class LoginViewModel : BaseViewModel
    {
        #region Atributos




        #endregion attrib



        #region Propiedades
        public String NOMBRE_USUARIO { get; set; }
        public String CLAVE { get; set; }

        #endregion prop


        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(UserLogin);
            }
        }

        public LoginViewModel()
        {

        }



        private async void UserLogin()
        {
            
            var usuarioIngresado = new Usuario();
            usuarioIngresado.NOMBRE_USUARIO = this.NOMBRE_USUARIO;
            usuarioIngresado.CLAVE = this.CLAVE;


            try
            {


                var usuarioGuardado = await App.Database.GetUserAsync(usuarioIngresado.NOMBRE_USUARIO);


                if (usuarioGuardado.CLAVE.Equals(usuarioIngresado.CLAVE))
                {
                    
                    var viewModel = MainViewModel.GetInstance(); // Instancia actual del MainViewModel
                    //viewModel.MainView = new MainViewViewModel();// Se crea un nuevo MainViewViewModel en la instancia actual

                    //var mainView = MainViewViewModel.GetInstance(); //Instancia actual de MainViewViewModel
                    viewModel.Usuario = usuarioGuardado;// Con la instancia MainView inicializada, se setea el valor Usuario

                    viewModel.SetImageSource(usuarioGuardado.IMAGEN);


                    Application.Current.MainPage = new NavigationPage(new MasterPage()); //Nuevo NavigationPage
                    //Application.Current.MainPage = new NavigationPage(new MainView()); //Nuevo NavigationPage


                }
                else
                {

                    await Application.Current.MainPage.DisplayAlert("", "Contraseña incorrecta ", "Continuar");
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }


        }

        #region Singleton

        private static LoginViewModel instance;

        public static LoginViewModel GetInstance()
        {
            if(instance == null)
            {
                return new LoginViewModel();
            }
            return instance;
        }

        #endregion


    }

}

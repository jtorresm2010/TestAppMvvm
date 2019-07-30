using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestAppMvvm.Models;
using Xamarin.Forms;

namespace TestAppMvvm.ViewModels
{
    public class UsuarioItemViewModel : Usuario
    {
    



        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(DeleteUser);
            }
        }

        private async void DeleteUser()
        {

            var usr = new Usuario
            {
                NOMBRE_USUARIO = this.NOMBRE_USUARIO,
                ID_USUARIO = this.ID_USUARIO,
                IMAGEN = this.IMAGEN,
                CLAVE = this.CLAVE
            };

            bool answer = await Application.Current.MainPage.DisplayAlert("Eliminar", "Desea eliminar al usuario ", "Si", "No");

            if (answer)
            {
                await App.Database.DeleteUserAsync(usr);

                var mainViewViewModel = MainViewViewModel.GetInstance();

                var deletedUser = mainViewViewModel.Usuarios.Where(p => p.ID_USUARIO == this.ID_USUARIO).FirstOrDefault();
                if(deletedUser != null)
                {
                    mainViewViewModel.Usuarios.Remove(deletedUser);
                }


                await Application.Current.MainPage.DisplayAlert("", "Eliminado", "Continuar");
            }



        }

        public ICommand UserTappedCommand
        {
            get
            {
                return new RelayCommand(UserTapped);
            }
        }

        private async void UserTapped()
        {
            await Application.Current.MainPage.DisplayAlert("", "Tapped: " + this.NOMBRE_USUARIO, "Continuar");
        }

        public ICommand User2TappedCommand
        {
            get
            {
                return new RelayCommand(User2Tapped);
            }
        }

        private async void User2Tapped()
        {
            var usr = new Usuario
            {
                NOMBRE_USUARIO = this.NOMBRE_USUARIO,
                ID_USUARIO = this.ID_USUARIO,
                IMAGEN = this.IMAGEN,
                CLAVE = this.CLAVE
            };

            bool answer = await Application.Current.MainPage.DisplayAlert("Eliminar", "Desea eliminar al usuario ", "Si", "No");

            if (answer)
            {
                await App.Database.DeleteUserAsync(usr);

                var mainViewViewModel = MainViewViewModel.GetInstance();

                var deletedUser = mainViewViewModel.Usuarios.Where(p => p.ID_USUARIO == this.ID_USUARIO).FirstOrDefault();
                if (deletedUser != null)
                {
                    mainViewViewModel.Usuarios.Remove(deletedUser);
                }


                await Application.Current.MainPage.DisplayAlert("", "Eliminado", "Continuar");
            }
        }



    }

}

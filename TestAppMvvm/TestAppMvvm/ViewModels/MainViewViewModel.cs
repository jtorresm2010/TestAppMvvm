using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestAppMvvm.Models;
using TestAppMvvm.Views;
using Xamarin.Forms;

namespace TestAppMvvm.ViewModels
{
    public class MainViewViewModel : BaseViewModel
    {
        private Usuario usuario;

        private ImageSource imageSource;

        private MediaFile file;



        public string NOMBRE_USUARIO { get; set; }
        public string imagen { get; set; }
        public Usuario Usuario
            {
                get { return this.usuario; }
                set { this.SetValue(ref this.usuario, value); }
            }


        public ObservableCollection<UsuarioItemViewModel> usuarios;

        public bool isRefreshing;

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { this.SetValue(ref this.imageSource, value); }
        }

        public ObservableCollection<UsuarioItemViewModel> Usuarios
        {

            get { return this.usuarios; }
            set { this.SetValue(ref this.usuarios, value); } /* al momento de setear el atributo se ejecuta SetValue, que se encuentra en la clase BaseViewModel. Esto actualiza sus valores */

        }

        public MainViewViewModel()
        {
            LoadUsers();
            
            instance = this;

        }

        #region Singleton

        private static MainViewViewModel instance;

        public static MainViewViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewViewModel();
            }
            return instance;
        }

        #endregion

        public void SetImageSource(String source)
        {
          

            if (source == null)
            {
                imageSource = ImageSource.FromResource("TestAppMvvm.Images.userPlaceholder.png", typeof(LoginView).GetTypeInfo().Assembly);
            }
            else
            {
                imageSource = Usuario.IMAGEN;


            }
                

        }

        private async void LoadUsers() // carga la lista de usuarios
        {
            this.IsRefreshing = true;

            var list = await App.Database.GetUsersAsync();

            var Mylist = list.Select(p => new UsuarioItemViewModel
            {
                ID_USUARIO = p.ID_USUARIO,
                NOMBRE_USUARIO = p.NOMBRE_USUARIO,
                CLAVE = p.CLAVE,
                IMAGEN = p.IMAGEN
                
            });

            this.Usuarios = new ObservableCollection<UsuarioItemViewModel>(Mylist);

            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadUsers);
            }
        }
        public ICommand ChangeImageCommand
        {

                get
                {
                    return new RelayCommand(ChangeImage);
                }

        }

        private async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();

            var source = await Application.Current.MainPage.DisplayActionSheet(
                "Seleccione origen de la imagen",
                "Cancelar",
                null,
                "Galeria",
                "Camara"
                );

            if(source == "Cancelar")
            {
                this.file = null;
                return;
            }

            if(source == "Camara")
            {
                this.file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions
                        {
                            Directory = "Sample",
                            Name = "test.jpg",
                            PhotoSize = PhotoSize.Small,
                        }
                    );
            }
            else
            {
                this.file = await CrossMedia.Current.PickPhotoAsync();
            }

            if(this.file != null)
            {
                this.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = this.file.GetStream();

                    //UpdateUserImage();
                    return stream;
                });
            }


        }






    }


}

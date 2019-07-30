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
    class MainViewModel : BaseViewModel
    {
        private Usuario usuario;

        private ImageSource imageSource;

        private MediaFile file;

        public bool isRefreshing;

        public ObservableCollection<UsuarioItemViewModel> usuarios;


        public Usuario Usuario
        {
            get { return this.usuario; }
            set { this.SetValue(ref this.usuario, value); }
        }

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

        public LoginViewModel Login { get; set; }

        public MainViewModel()
        {

            #region iniciar bdd
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
            #endregion

            LoadUsers();

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

        #region Singleton

        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return instance;
        }

        #endregion sing

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

        public void SetImageSource(String source)
        {


            if (string.IsNullOrEmpty(source))
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

            if (source == "Cancelar")
            {
                this.file = null;
                return;
            }

            if (source == "Camara")
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

            if (this.file != null)
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

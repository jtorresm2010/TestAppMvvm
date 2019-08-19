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
        public ObservableCollection<ItemInspeccion> ItemsInspeccion { get; set; }

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


        public void GetListaItems()
        {
            var listaItems = new List<ItemInspeccion>();

            listaItems.AddRange(new[]
            {

           
                new ItemInspeccion
                {
                    Nombre = "Llave original con chip", Area="1", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Segunda llave original con chip", Area="1", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Manual propietario", Area="1", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Libro de mantención", Area="1", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Placas patentes", Area="1", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },

            
                new ItemInspeccion
                {
                    Nombre = "Aire acondicionado", Area="2", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Climatizador", Area="2", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "ABS", Area="2", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Airbags laterales", Area="2", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Cinturones pirotécnicos", Area="2", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
        
                new ItemInspeccion
                {
                    Nombre = "Motor", Area="3", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Nivel de aceite", Area="3", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Radiador", Area="3", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Tapa del combustible", Area="3", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Pérdidas de agua", Area="3", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
              
                new ItemInspeccion
                {
                    Nombre = "Volante", Area="4", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Asientos delanteros", Area="4", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Asientos traseros", Area="4", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Piso, alfombra", Area="4", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Espejo retrovisor interior", Area="4", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
           
                new ItemInspeccion
                {
                    Nombre = "Tablero encendido", Area="5", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Cabina general", Area="5", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Llaves y documentos", Area="5", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Asientos delanteros", Area="5", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Asientos traseros", Area="5", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
          
                new ItemInspeccion
                {
                    Nombre = "Parachoques delanteros", Area="6", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Frontal interior", Area="6", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Capot", Area="6", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Tapabarro derecho", Area="6", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Costado Tras. Der.", Area="6", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
        
                new ItemInspeccion
                {
                    Nombre = "Frontal", Area="7", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Lateral izquierdo", Area="7", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Lateral derecho", Area="7", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Techo", Area="7", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Capot", Area="7", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
               
                new ItemInspeccion
                {
                    Nombre = "Arranque", Area="8", Deshabilitable= false, RequiereFoto = true, Tipo = "2"
                },
                new ItemInspeccion
                {
                    Nombre = "Aceleración", Area="8", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Vibraciones", Area="8", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Alineación", Area="8", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },
                new ItemInspeccion
                {
                    Nombre = "Suspensión", Area="8", Deshabilitable= false, RequiereFoto = true, Tipo = "1"
                },


            });


            ItemsInspeccion = new ObservableCollection<ItemInspeccion>(listaItems);


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

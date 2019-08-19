using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppMvvm.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestAppMvvm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestCollectionView : ContentPage
    {
        public TestCollectionView()
        {
            
            InitializeComponent();
            var mainInstance = MainViewModel.GetInstance();
            mainInstance.GetListaItems();

            
            collectionList.ItemsSource = mainInstance.ItemsInspeccion;
            
        }
    }
}
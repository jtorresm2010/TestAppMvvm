using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppMvvm.Models;
using TestAppMvvm.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestAppMvvm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccordionRepeaterView : ContentPage
    {

        private readonly CustomSampleViewModel _viewModel;

        public AccordionRepeaterView()
        {
            InitializeComponent();
            //_viewModel = new CustomSampleViewModel();

            //BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            AccordionMenu.ItemsSource = LoadData();
           // ElemList.ItemSource = LoadData();
            //await _viewModel.LoadData();
        }

        private List<RandomObject> LoadData()
        {
            int _loadingCount = 1;
            var items = new List<RandomObject>
                {
                    new RandomObject{ RandomProperty1=$"{_loadingCount}", RandomProperty2="red", RandomProperty3 = "cat",  RandomProperty4 = "apples", ItemEnabled=true},
                    new RandomObject{ RandomProperty1=$"{_loadingCount+1}", RandomProperty2="blue", RandomProperty3 = "dog",  RandomProperty4 = "oranges", ItemEnabled=false},
                    new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
                    new RandomObject{ RandomProperty1=$"{_loadingCount+3}", RandomProperty2="purple", RandomProperty3 = "platypus",  RandomProperty4 = "ananas", ItemEnabled=false}
                };

            return items;
        }
    }
}
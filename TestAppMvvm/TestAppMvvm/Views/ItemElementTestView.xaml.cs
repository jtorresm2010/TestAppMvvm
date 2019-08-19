using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppMvvm.Models;
using TestAppMvvm.Services;
using TestAppMvvm.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestAppMvvm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemElementTestView : StackLayout
    {

        private readonly CustomSampleViewModel _viewModel;

        //Data templates
        DataTemplate validTemplate;
        DataTemplate invalidTemplate;


        public ItemElementTestView()
        {
            InitializeComponent();

            var people = new List<Person>
            {
                new Person { Name = "Kath", DateOfBirth = new DateTime(1985, 11, 20), Location = "France" },
                new Person { Name = "Steve", DateOfBirth = new DateTime(1975, 1, 15), Location = "USA" },
                new Person { Name = "Lucas", DateOfBirth = new DateTime(1988, 2, 5), Location = "Germany" },
                new Person { Name = "John", DateOfBirth = new DateTime(1976, 2, 20), Location = "USA" },
                new Person { Name = "Tariq", DateOfBirth = new DateTime(1987, 1, 10), Location = "UK" },
                new Person { Name = "Jane", DateOfBirth = new DateTime(1982, 8, 30), Location = "USA" },
                new Person { Name = "Tom", DateOfBirth = new DateTime(1977, 3, 10), Location = "UK" }
            };

            SetupDataTemplates();

            
                
                
            var layout = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label {
                        Text = "ListView with a DataTemplateSelector",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new ListView {
                        Margin = new Thickness(0,20,0,0),
                        ItemsSource = people,
                        ItemTemplate = new PersonDataTemplateSelector {
                            ValidTemplate = validTemplate,
                            InvalidTemplate = invalidTemplate
                        }
                    }
                }
            };

            this.Children.Add(layout);




            //ElemList.ItemsSource = LoadData();
            //Idea, cada vez que se carguen los datos, la lista cambia
            // ElemList.ItemSource = LoadData();
            //await _viewModel.LoadData();
        }

        private void SetupDataTemplates()
        {
            validTemplate = (DataTemplate)Application.Current.Resources["validPersonTemplate"];
            invalidTemplate = (DataTemplate)Application.Current.Resources["invalidPersonTemplate"];
        }






        #region test random property datasource
        //private List<RandomObject> LoadData()
        //{
        //    int _loadingCount = 1;
        //    var items = new List<RandomObject>
        //        {
        //            new RandomObject{ RandomProperty1=$"{_loadingCount}", RandomProperty2="red", RandomProperty3 = "cat",  RandomProperty4 = "apples", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+1}", RandomProperty2="blue", RandomProperty3 = "dog",  RandomProperty4 = "oranges", ItemEnabled=false},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+3}", RandomProperty2="purple", RandomProperty3 = "platypus",  RandomProperty4 = "ananas", ItemEnabled=false},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //            new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
        //        };

        //    return items;
        //}
        #endregion randomprop
    }
}
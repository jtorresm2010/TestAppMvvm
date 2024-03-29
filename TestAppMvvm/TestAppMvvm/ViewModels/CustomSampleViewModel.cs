﻿using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestAppMvvm.Models;
using Xamarin.Forms;

namespace TestAppMvvm.ViewModels
{


    public class CustomSampleViewModel : BaseViewModel
    {
        private int _loadingCount = 1;

        private ICommand _selectedItemCommand;
        private ICommand _reloadItemCommand;
        private ICommand _setRandomSelectedItemCommand;
        private ICommand _leftPanelSelectCommand;

        public ICommand SelectedItemCommand => _selectedItemCommand ?? (_selectedItemCommand = new Command((selectedItem) => Select((RandomObject)selectedItem)));
        public ICommand ReloadItemCommand => _reloadItemCommand ?? (_reloadItemCommand = new Command(async () => await LoadData(true)));
        public ICommand SetRandomSelectedItemCommand => _setRandomSelectedItemCommand ?? (_setRandomSelectedItemCommand = new Command(SetRandomSelectedItem));
        public ICommand LeftPanelSelectCommand => _leftPanelSelectCommand ?? (_leftPanelSelectCommand = new Command((value) => LeftPanelSelect((string)value)));

        public ObservableRangeCollection<RandomObject> Items { get; } = new ObservableRangeCollection<RandomObject>();


        public string SelectedValue { get; set; } = "No selection";
        public object SelectedItem { get; set; }

        public async Task LoadData(bool isReloading = false)
        {
            IsBusy = true;

            if (isReloading)
                _loadingCount++;

            try
            {
                var items = new List<RandomObject>
                {
                    new RandomObject{ RandomProperty1=$"{_loadingCount}", RandomProperty2="red", RandomProperty3 = "cat",  RandomProperty4 = "apples", ItemEnabled=true},
                    new RandomObject{ RandomProperty1=$"{_loadingCount+1}", RandomProperty2="blue", RandomProperty3 = "dog",  RandomProperty4 = "oranges", ItemEnabled=false},
                    new RandomObject{ RandomProperty1=$"{_loadingCount+2}", RandomProperty2="green", RandomProperty3 = "fish",  RandomProperty4 = "kiwi", ItemEnabled=true},
                    new RandomObject{ RandomProperty1=$"{_loadingCount+3}", RandomProperty2="purple", RandomProperty3 = "platypus",  RandomProperty4 = "ananas", ItemEnabled=false}
                };

                if (isReloading)
                    await Task.Delay(5000);

                Items.ReplaceRange(items);
            }
            finally
            {
                IsBusy = false;
            }

        }

        public async Task LoadNullData(bool isReloading = false)
        {
            IsBusy = true;

            if (isReloading)
                _loadingCount++;

            if (isReloading)
                await Task.Delay(5000);

            Items.ReplaceRange(new List<RandomObject>());

            IsBusy = false;
        }

        private void Select(RandomObject selectedItem)
        {
            SelectedValue = $"Selected item {Items.IndexOf(selectedItem)}: {selectedItem.RandomProperty1} => {selectedItem.RandomProperty2} {selectedItem.RandomProperty3} eats {selectedItem.RandomProperty4}";

            OnPropertyChanged(nameof(SelectedValue));
        }

        private void SetRandomSelectedItem()
        {
            var randomItem = Items.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            SelectedItem = new RandomObject { RandomProperty1 = randomItem.RandomProperty1, RandomProperty2 = randomItem.RandomProperty2, RandomProperty3 = randomItem.RandomProperty3, RandomProperty4 = randomItem.RandomProperty4 };

            OnPropertyChanged(nameof(SelectedItem));
        }


        private void LeftPanelSelect(string value)
        {
            SelectedValue = $"SelectedLeftItem {value}";

            OnPropertyChanged(nameof(SelectedValue));
        }
    }
}



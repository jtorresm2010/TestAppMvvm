using System;
using System.Collections.Generic;
using System.Text;
using TestAppMvvm.Models;
using Xamarin.Forms;

namespace TestAppMvvm.Services
{
    public class PersonDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ValidTemplate { get; set; }

        public DataTemplate InvalidTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Person)item).DateOfBirth.Year >= 1980 ? ValidTemplate : InvalidTemplate;
        }
    }
}

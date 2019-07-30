using System;
using System.Collections.Generic;
using System.Text;
using TestAppMvvm.ViewModels;

namespace TestAppMvvm.Infrastructure
{ 
        class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }





    }
}

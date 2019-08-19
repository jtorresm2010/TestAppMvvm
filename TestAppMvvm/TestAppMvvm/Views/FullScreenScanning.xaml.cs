using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace TestAppMvvm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullScreenScanning : ZXingScannerPage
    {
        public FullScreenScanning()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            Debug.WriteLine("Cargando Pagina OnAppearing FullScreenScanning");
            base.OnAppearing();
            IsScanning = true;
        }

        public void Handle_OnScanResult(Result result)
        {
           
            // your code here.
            Debug.WriteLine("Cargando Pagina Handle_OnScanResult FullScreenScanning");
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Scanned result", result.Text, "OK");
            });


        }

        protected override void OnDisappearing()
        {

            // your code here.
            Debug.WriteLine("Cargando Pagina OnDisappearing FullScreenScanning");
            base.OnDisappearing();
            IsScanning = false;

        }

    }
}
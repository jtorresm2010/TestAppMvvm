using System.IO;

using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestAppMvvm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkiasTest : ContentPage
    {
        public SkiasTest()
        {
            InitializeComponent();

            TestImage.Source = CreateImage(0);
        }

        private ImageSource CreateImage(int numero)
        {
            SKSurface surface;
            SKImage image;
            

            var info = new SKImageInfo(40, 40);
            using (surface = SKSurface.Create(info))
            {
                SKCanvas canvas = surface.Canvas;

                SKPaint paint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = SKColors.White
                };
                canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);

                image = surface.Snapshot();
            }
            SKData encoded = image.Encode();
            Stream stream = encoded.AsStream();

            return ImageSource.FromStream(() => stream);
        }
    }
}
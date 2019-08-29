using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace TestAppMvvm.Utils
{
    public class Utils
    {

        //Devuelve un Imagesource con las dimensiones especificadas usando skias
        public ImageSource CreateImage(int width, int height)
        {
            SKSurface surface;
            SKImage image;

            var info = new SKImageInfo(width, height);

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

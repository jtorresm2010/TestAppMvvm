﻿using Android.Content;
using Android.Graphics;
using PCLStorage;
using System;
using System.IO;
using TestAppMvvm.Customs;
using TestAppMvvm.Droid.Customs.Camera2;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraViewServiceRenderer))]
namespace TestAppMvvm.Droid.Customs.Camera2
{
    public class CameraViewServiceRenderer : ViewRenderer<CameraPreview, CameraDroid>
    {
        private CameraDroid _camera;
        private CameraPreview _currentElement;
        private readonly Context _context;

        public CameraViewServiceRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
        {
            base.OnElementChanged(e);

            _camera = new CameraDroid(Context);

            SetNativeControl(_camera);

            if (e.NewElement != null && _camera != null)
            {
                e.NewElement.CameraClick = new Command(() => TakePicture());
                _currentElement = e.NewElement;
                _camera.SetCameraOption(_currentElement.Camera);
                _camera.Photo += OnPhoto;
            }
        }

        public void TakePicture()
        {
            _camera.LockFocus();
        }

        private void OnPhoto(object sender, byte[] imgSource)
        {

            
            var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);

            

            File.WriteAllBytes(path + "/Clicar/test002.Jpeg", imgSource);


            Device.BeginInvokeOnMainThread(() =>
            {
                _currentElement?.PictureTaken();
            });
        }








        protected override void Dispose(bool disposing)
        {
            _camera.Photo -= OnPhoto;

            base.Dispose(disposing);
        }
    }
}
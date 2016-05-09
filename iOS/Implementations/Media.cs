using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(TDCArcTouch.iOS.Media))]
namespace TDCArcTouch.iOS
{
    public class Media : IMedia
    {
        private UIImagePickerControllerDelegate pickerDelegate;

        public Task<string> FromGallery()
        {
            UIWindow window = GetRootWindow();
            if (window == null)
            {
                throw new InvalidOperationException("No root controller.");
            }

            var viewController = window.RootViewController;
            while (viewController.PresentedViewController != null)
            {
                viewController = viewController.PresentedViewController;
            }

            var ndelegate = new GalleryDelegate(viewController);
            var od = Interlocked.CompareExchange(ref pickerDelegate, ndelegate, null);
            if (od != null)
            {
                throw new InvalidOperationException("Delegate still running");
            }

            var picker = new GalleryController(ndelegate)
            {
                MediaTypes = new string[]{ "public.image" },
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary
            };

            viewController.PresentViewController(picker, true, null);

            return ndelegate.Task.ContinueWith(
                t =>
                {
                    Interlocked.Exchange(ref pickerDelegate, null);
                    return t;
                }).Unwrap();
        }

        private static UIWindow GetRootWindow()
        {
            var windows = UIApplication.SharedApplication.Windows;
            foreach (var window in windows)
            {
                if (window.RootViewController != null)
                {
                    return window;
                }
            }

            return UIApplication.SharedApplication.KeyWindow;
        }
    }
}


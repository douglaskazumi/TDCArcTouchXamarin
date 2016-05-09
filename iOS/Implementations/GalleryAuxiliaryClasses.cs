using System;
using UIKit;
using Foundation;
using System.Threading.Tasks;
using System.IO;

namespace TDCArcTouch.iOS
{
    public sealed class GalleryController : UIImagePickerController
    {
        internal GalleryController(GalleryDelegate mpDelegate)
        {
            base.Delegate = mpDelegate;
        }

        public override NSObject Delegate
        {
            get
            {
                return base.Delegate;
            }
        }

        public Task<string> GetResultAsync()
        {
            return ((GalleryDelegate)Delegate).Task;
        }
    }

    internal class GalleryDelegate : UIImagePickerControllerDelegate
    {
        private readonly TaskCompletionSource<string> task = new TaskCompletionSource<string>();
        private readonly UIViewController viewController;

        internal GalleryDelegate(UIViewController viewController)
        {
            this.viewController = viewController;
        }

        public UIView View
        {
            get
            {
                return viewController.View;
            }
        }

        public Task<string> Task
        {
            get
            {
                return task.Task;
            }
        }

        public override void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
        {
            string mediaFile = GetPictureMediaFile(info);

            Action onDismiss = () => task.TrySetResult(mediaFile);
            if (viewController == null)
            {
                onDismiss();
            }
            else
            {
                picker.DismissViewController(true, onDismiss);
                picker.Dispose();
            }
        }

        public override void Canceled(UIImagePickerController picker)
        {
            Action onDismiss = () => task.TrySetResult("");
            if (viewController == null)
            {
                onDismiss();
            }
            else
            {
                picker.DismissViewController(true, onDismiss);
                picker.Dispose();
            }
        }

        private string GetPictureMediaFile(NSDictionary info)
        {
            var image = (UIImage)info[UIImagePickerController.EditedImage];
            if (image == null)
            {
                image = (UIImage)info[UIImagePickerController.OriginalImage];
            }

            var path = GetOutputPath();

            using (var fs = File.OpenWrite(path))
            using (Stream s = new NSDataStream(image.AsJPEG()))
            {
                s.CopyTo(fs);
                fs.Flush();
            }

            return path;
        }

        private static string GetOutputPath()
        {
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "tdc");
            Directory.CreateDirectory(path);
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

            return Path.Combine(path, fileName);
        }
    }

    internal unsafe class NSDataStream : UnmanagedMemoryStream
    {
        private readonly NSData data;

        public NSDataStream(NSData data)
            : base((byte*)data.Bytes, (long)data.Length)
        {
            this.data = data;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.data.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}


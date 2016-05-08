// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Media.cs" company="ArcTouch LLC">
//   Copyright 2016 ArcTouch LLC.
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the Media type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using UIKit;
using Foundation;
using AVFoundation;
using System.Threading;
using System.IO;

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

        private string GetPictureMediaFile(NSDictionary info)
        {
            var image = (UIImage)info[UIImagePickerController.EditedImage];
            if (image == null)
            {
                image = (UIImage)info[UIImagePickerController.OriginalImage];
            }

            var path = GetOutputPath();

            using (var fs = File.OpenWrite(path))
            using (Stream s = new NsDataStream(image.AsJPEG()))
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

    internal unsafe class NsDataStream : UnmanagedMemoryStream
    {
        private readonly NSData data;

        public NsDataStream(NSData data)
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


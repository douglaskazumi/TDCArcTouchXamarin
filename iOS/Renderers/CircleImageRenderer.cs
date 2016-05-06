//
// Copyright 2016 ArcTouch LLC.
// All rights reserved.
//
// This file, its contents, concepts, methods, behavior, and operation
// (collectively the "Software") are protected by trade secret, patent,
// and copyright laws. The use of the Software is governed by a license
// agreement. Disclosure of the Software to third parties, in any form,
// in whole or in part, is expressly prohibited except as authorized by
// the license agreement.
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using TDCArcTouch;
using TDCArcTouch.iOS;

using UIKit;

[assembly: ExportRendererAttribute(typeof(CircleImage), typeof(CircleImageRenderer))]
namespace TDCArcTouch.iOS
{
	public class CircleImageRenderer : ViewRenderer<CircleImage, UIView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<CircleImage> e)
		{
			if (e.NewElement == null)
			{
				return;
			}

			base.OnElementChanged(e);

			var image = e.NewElement;

			SetNativeControl(new UIView());

			if (image != null && image.Source != null) 
			{
				UpdateCircleImage(image);            
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) 
		{
			base.OnElementPropertyChanged(sender, e);

			CircleImage image = (CircleImage)sender;

			if (e.PropertyName == CircleImage.BorderColorProperty.PropertyName
				|| e.PropertyName == CircleImage.BorderWidthProperty.PropertyName
				|| e.PropertyName == CircleImage.SourceProperty.PropertyName)
			{
				UpdateCircleImage(image);
			}
		}

		private async void UpdateCircleImage(CircleImage image)
		{
			UIImageView circleImageView = new UIImageView();
			circleImageView.Image = await GetUIImageFromImageSource(image.Source);
			var radius = Math.Min(image.WidthRequest, image.HeightRequest);
			circleImageView.Frame = new RectangleF(0, 0, (float) radius, (float) radius);
			circleImageView.Layer.CornerRadius = (float) radius / 2;
			circleImageView.Layer.BorderWidth = (float)this.Element.BorderWidth;
			circleImageView.Layer.BorderColor = this.Element.BorderColor.ToCGColor();
			circleImageView.ClipsToBounds = true;
			SetNativeControl(circleImageView);
		}

		private Task<UIImage> GetUIImageFromImageSource(ImageSource imageSource)
		{
			IImageSourceHandler handler = null;

			if (imageSource is FileImageSource)
			{
				handler = new FileImageSourceHandler();
			}
			else if (imageSource is StreamImageSource)
			{
				handler = new StreamImagesourceHandler(); 
			}
			else if (imageSource is UriImageSource)
			{
				handler = new ImageLoaderSourceHandler();
			}
			else
			{
				throw new NotImplementedException();
			}

			return handler.LoadImageAsync(imageSource);
		}
	}
}


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

using Xamarin.Forms;

namespace TDCArcTouch
{
	public class CircleImage : Image
	{
		public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(CircleImage), 0.0);

		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CircleImage), Color.White);

		public CircleImage()
		{
		}

		public double BorderWidth
		{
			get 
			{ 
				return (double) base.GetValue(BorderWidthProperty);
			}
			set 
			{ 
				base.SetValue(BorderWidthProperty, value);
			}
		}

		public Color BorderColor
		{
			get 
			{ 
				return (Color)base.GetValue(BorderColorProperty);
			}
			set 
			{ 
				base.SetValue(BorderColorProperty, value);
			}
		}

	}
}


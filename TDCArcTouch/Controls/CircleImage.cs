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


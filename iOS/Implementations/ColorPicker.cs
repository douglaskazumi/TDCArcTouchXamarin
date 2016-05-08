using System;

using InfColorPickerBinding;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(TDCArcTouch.iOS.ColorPicker))]
namespace TDCArcTouch.iOS
{
	public class ColorPicker : IColorPicker
	{
		public void Show()
		{
			UIWindow window = UIApplication.SharedApplication.KeyWindow;

			if (window == null)
			{
				throw new InvalidOperationException("There's no current active window");
			}

			var viewController = window.RootViewController;

			ColorSelectedDelegate selector = new ColorSelectedDelegate(viewController);

			InfColorPickerController picker = InfColorPickerController.ColorPickerViewController;
			picker.Delegate = selector;
			picker.PresentModallyOverViewController(viewController);
		}
	}
}
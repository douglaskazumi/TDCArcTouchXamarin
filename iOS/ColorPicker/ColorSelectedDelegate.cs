using System;

using UIKit;

using InfColorPickerBinding;

using Xamarin.Forms;

namespace TDCArcTouch.iOS
{
	public class ColorSelectedDelegate : InfColorPickerControllerDelegate
	{
		readonly UIViewController parent;

		public ColorSelectedDelegate(UIViewController parent)
		{
			this.parent = parent;
		}

		public override void ColorPickerControllerDidFinish(InfColorPickerController controller)
		{
			nfloat red;
			nfloat green;
			nfloat blue;
			nfloat alpha;
			controller.ResultColor.GetRGBA(out red, out green, out blue, out alpha);

			Color color = new Color(red, green, blue, alpha);

			parent.DismissViewController(false, () =>
				{
					MessagingCenter.Send<App, Color>(((App)App.Current), Messages.COLOR_PICKED, color);
				});
		}
	}
}
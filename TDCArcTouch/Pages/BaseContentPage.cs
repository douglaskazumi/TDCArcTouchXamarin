using Xamarin.Forms;

namespace TDCArcTouch
{
	public class BaseContentPage : ContentPage
	{
		public BasePageModel basePageModel;

		public BaseContentPage()
		{
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			basePageModel?.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			basePageModel?.OnDisappearing();

			base.OnDisappearing();
		}
	}
}


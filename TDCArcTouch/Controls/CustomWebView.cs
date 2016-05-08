using System;

using Xamarin.Forms;

namespace TDCArcTouch
{
	public class CustomWebView : WebView
	{
		public CustomWebView()
		{
			Navigating += CustomWebView_Navigating;
		}

		private void CustomWebView_Navigating(object sender, WebNavigatingEventArgs e)
		{
			if (e.Url.StartsWith("http"))
			{
				Device.OpenUri(new Uri(e.Url));
			}
		}
	}
}


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


using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TDCArcTouch
{
	public partial class AdvancedPage : ContentPage
	{
        public AdvancedPage()
		{
			InitializeComponent();
            BindingContext = new AdvancedPageModel();
		}
	}
}


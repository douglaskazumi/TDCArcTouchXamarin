using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TDCArcTouch
{
	public partial class CustomPage : BaseContentPage
	{
		public CustomPage()
		{
			InitializeComponent();
			basePageModel = new CustomPageModel();
			BindingContext = basePageModel;
		}
	}
}


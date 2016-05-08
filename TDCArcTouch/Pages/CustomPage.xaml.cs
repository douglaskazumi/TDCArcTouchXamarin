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
			this.basePageModel = new CustomPageModel();
			BindingContext = this.basePageModel;
		}
	}
}


using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TDCArcTouch
{
    public partial class AdvancedPage : BaseContentPage
	{
        public AdvancedPage()
		{
			InitializeComponent();
            this.basePageModel = new AdvancedPageModel();
            BindingContext = this.basePageModel;
		}
	}
}


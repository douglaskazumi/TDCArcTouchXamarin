using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TDCArcTouch
{
    public partial class DependencyPage : BaseContentPage
	{
        public DependencyPage()
		{
			InitializeComponent();
            this.basePageModel = new DependencyPageModel();
            BindingContext = this.basePageModel;
		}
	}
}


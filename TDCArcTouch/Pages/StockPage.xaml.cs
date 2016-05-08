using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TDCArcTouch
{
	public partial class StockPage : BaseContentPage
    {
        public StockPage()
        {
            InitializeComponent();
            BindingContext = new StockPageModel();
        }
    }
}


using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TDCArcTouch
{
    public class MenuPageItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }

    public partial class MenuPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MenuPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MenuPageItem>();
            masterPageItems.Add(new MenuPageItem { Title = "Stock Page", TargetType = typeof(StockPage) });
			masterPageItems.Add(new MenuPageItem { Title = "Custom Page", TargetType = typeof(CustomPage) });
            masterPageItems.Add(new MenuPageItem { Title = "Advanced Page", TargetType = typeof(AdvancedPage) });

            listView.ItemsSource = masterPageItems;
		}

		private void OnFreepikLinkTapped(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("http://www.freepik.com"));
		}

		private void OnFlatIconLinkTapped(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("http://www.flaticon.com"));
		}

		private void OnCCLinkTapped(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("http://creativecommons.org/licenses/by/3.0/"));
		}
    }
}


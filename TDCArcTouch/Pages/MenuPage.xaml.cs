// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuPage.xaml.cs" company="ArcTouch LLC">
//   Copyright 2016 ArcTouch LLC.
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the MenuPage.xaml type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
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
            masterPageItems.Add(new MenuPageItem { Title = "Custom Page", TargetType = typeof(StockPage) });
            masterPageItems.Add(new MenuPageItem { Title = "Advanced Page", TargetType = typeof(StockPage) });

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


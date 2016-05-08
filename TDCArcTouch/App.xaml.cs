// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="ArcTouch LLC">
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
//   Defines the App.xaml type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace TDCArcTouch
{
    public partial class App : Application
    {
        private MasterDetailPage masterDetail;

        public App()
        {
            InitializeComponent();

            this.masterDetail = new MasterDetailPage();
            var menu = new MenuPage();
            menu.ListView.ItemSelected += MenuItemSelected;
            this.masterDetail.Master = menu;
            this.masterDetail.Detail = new NavigationPage(new StockPage());
			MainPage = this.masterDetail;
		}

        public async Task DisplayAlert(string message, string title = "TDC ArcTouch", string cancel = "OK")
        {
            await masterDetail.DisplayAlert(title,message,cancel);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void MenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuPageItem;
            if (item != null)
            {
                this.masterDetail.Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                (this.masterDetail.Master as MenuPage).ListView.SelectedItem = null;
                this.masterDetail.IsPresented = false;
            }
        }
    }
}


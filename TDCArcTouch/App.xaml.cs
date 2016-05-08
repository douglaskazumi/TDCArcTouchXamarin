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
            this.masterDetail.Detail = new NavigationPage(new AdvancedPage());
			MainPage = this.masterDetail;
		}

        public async Task DisplayAlert(string message, string title = "TDC ArcTouch", string cancel = "OK")
        {
            await masterDetail.DisplayAlert(title,message,cancel);
        }

        public void NavigateTo<T>()
        {
            var newPage = (Page)Activator.CreateInstance(typeof(T));
            this.masterDetail.Detail = new NavigationPage(newPage);
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


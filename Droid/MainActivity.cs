using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms;

namespace TDCArcTouch.Droid
{
    [Activity(Label = "TDCArcTouch.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			RequestedOrientation = Device.Idiom == TargetIdiom.Tablet ? 
				ScreenOrientation.Landscape : ScreenOrientation.Portrait;

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}


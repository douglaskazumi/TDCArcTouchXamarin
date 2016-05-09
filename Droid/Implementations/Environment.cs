using System;

[assembly: Xamarin.Forms.Dependency(typeof(TDCArcTouch.Droid.Environment))]
namespace TDCArcTouch.Droid
{
	public class Environment : IEnvironment
	{
		public string GetAppVersion()
		{
			return Xamarin.Forms.Forms.Context.PackageManager.GetPackageInfo(Xamarin.Forms.Forms.Context.PackageName, 0).VersionName;
		}
	}
}
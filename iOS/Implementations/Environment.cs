using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(TDCArcTouch.iOS.Environment))]
namespace TDCArcTouch.iOS
{
	public class Environment : IEnvironment
	{
		public string GetAppVersion()
		{
			return NSBundle.MainBundle.InfoDictionary["CFBundleVersion"].ToString();
		}
	}
}
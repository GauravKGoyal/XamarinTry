using Foundation;
using UIKit;
using Xamarin.Forms;
using XamarinTry.iOS;

[assembly: Dependency(typeof(Dialer))]
namespace XamarinTry.iOS
{
    class Dialer : IDialer
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
				new NSUrl("tel:" + number));
        }
    }
}

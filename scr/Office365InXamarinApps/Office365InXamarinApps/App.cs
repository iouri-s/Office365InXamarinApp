#if Android
using Android.Content;
#else
using MonoTouch.UIKit;
#endif

using Office365InXamarinApps.Views;
using Xamarin.Forms;

namespace Office365InXamarinApps
{
	public class App
	{

#if iOS
        public static UIViewController Context { get; set; }
#else
        public static Context Context{get;set;}
#endif
        public static Page GetContactsView()
		{
            return new ContactsView();
		}
	}
}

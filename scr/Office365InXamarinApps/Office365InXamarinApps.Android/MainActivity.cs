using Android.App;
using Android.OS;

using Xamarin.Forms.Platform.Android;

namespace Office365InXamarinApps
{
    [Activity(Label = "Office365InXamarinApps", MainLauncher = true)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            App.Context = this;
            SetPage(App.GetContactsView());
        }
    }
}


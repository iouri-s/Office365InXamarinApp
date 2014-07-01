using System.Collections.ObjectModel;
#if iOS
using MonoTouch.UIKit;
#elif Android
using Android.Content;
#endif

using Microsoft.Office365.Exchange;
using Microsoft.Office365.OAuth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Office365InXamarinApps.ViewModel
{
    public class ContactsViewModel : Xamarin.Forms.Labs.Mvvm.ViewModel
    {
        private const string ExchangeResourceId = "https://outlook.office365.com";
        private const string ExchangeServiceRoot = "https://outlook.office365.com/ews/odata";
        
        public async void LoadData()
        {
            try
            {
                Contacts = new ObservableCollection<IContact>(await GetContacts(App.Context));
            }
            catch (Exception e)
            {
                //todo handle this
                var error = e.ToString();
            }
        }

        private ObservableCollection<IContact> _contacts;
 
        private ObservableCollection<IContact> Contacts 
        {
            get { return _contacts; }
            set { _contacts = value; }
        }

#if iOS
        public async Task<IEnumerable<IContact>> GetContacts(UIViewController context)
#else
        public async Task<IEnumerable<IContact>> GetContacts(Context context)
#endif
        {
            try
            {
                var client = await EnsureClientCreated(context);

                // Obtain first page of contacts
                var contactsResults = await (from i in client.Me.Contacts
                                             orderby i.DisplayName
                                             select i).Take(20).ExecuteAsync();

                return contactsResults.CurrentPage;
            }
            catch (Exception exception)
            {
                //todo handle this
                var error = exception.ToString();
            }
            return null;
        }

#if iOS
        private async Task<ExchangeClient> EnsureClientCreated(UIViewController context)
#else
        private async Task<ExchangeClient> EnsureClientCreated(Context context)
#endif
        {
            var authenticator = new Authenticator(context);
            var authInfo = await authenticator.AuthenticateAsync(ExchangeResourceId);

            return new ExchangeClient(new Uri(ExchangeServiceRoot), authInfo.GetAccessToken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office365InXamarinApps.ViewModel;
using Xamarin.Forms;

namespace Office365InXamarinApps.Views
{
	public partial class ContactsView
	{
		public ContactsView()
		{
			InitializeComponent();
			var viewModel = new ContactsViewModel();
			BindingContext = viewModel;
			viewModel.LoadData();
			NavigationPage.SetHasNavigationBar(this, true);
		}
	}
}

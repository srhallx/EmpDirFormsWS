using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using EmployeeDirectory;

namespace EmpDirForms
{
	public partial class EmpDirList : ContentPage
	{
		public EmpDirList ()
		{
			InitializeComponent ();

			//Pull to refresh
			itemListview.IsPullToRefreshEnabled = true;

			itemListview.Refreshing += async (sender, e) => {
				EmployeeDirectoryClient client = new EmployeeDirectoryClient();
				itemListview.ItemsSource = await client.GetAllEmployees();
				itemListview.EndRefresh();
			};

			//Refresh List
			itemListview.BeginRefresh ();


			//Item clicked
			itemListview.ItemSelected += async (sender, e) =>  {

				if (e.SelectedItem == null)
					return;
				
				var selectedData = (Employee)e.SelectedItem;

				//Retrieve geo data
				EmployeeDirectoryClient client = new EmployeeDirectoryClient();
				selectedData.Loc = await client.GetLocation(selectedData.City);

				var nextPage = new EmpDirDetail(selectedData);

				await Navigation.PushAsync(nextPage);

				itemListview.SelectedItem = null;
			};
		}

		public void OnMore (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}
	}
}


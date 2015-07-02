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
				itemListview.ItemsSource = await App.EmpDirClient.AllEmployees();
				itemListview.EndRefresh();
			};

			//Refresh List
			itemListview.BeginRefresh ();


			//Item clicked
			itemListview.ItemSelected += async (sender, e) =>  {
				var selectedData = (Employee)e.SelectedItem;

				//Retrieve geo data
				selectedData.GeoLocation = await App.EmpDirClient.GetGeolocation(selectedData.City);

				var nextPage = new EmpDirDetail(selectedData);

				await Navigation.PushAsync(nextPage);

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


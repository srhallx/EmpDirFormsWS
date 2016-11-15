using System;
using System.Collections.Generic;
using EmployeeDirectory;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace EmpDirForms
{
	public partial class EmpDirDetail : ContentPage
	{
		public EmpDirDetail (Employee data)
		{

			InitializeComponent ();

			//Bind data to form
			this.BindingContext = data;

			Device.OnPlatform(iOS: ()=>AddMaps(data));

		}

		private void AddMaps(Employee data) {

			var map = new Map ();
			map.WidthRequest = 270;
			map.HeightRequest = 160;
			map.MapType = MapType.Street;

			MainLayout.Children.Add (map);

			//Center map on city
			map.MoveToRegion(
				MapSpan.FromCenterAndRadius(
					new Position(data.Loc.lat, data.Loc.lng), Distance.FromMiles(5)));
		}
			
	}
}


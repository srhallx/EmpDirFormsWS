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

			//Center map on city
			MyMap.MoveToRegion(
				MapSpan.FromCenterAndRadius(
					new Position(data.GeoLocation.Lattitude,data.GeoLocation.Longitude), Distance.FromMiles(5)));
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using Worklight.Xamarin.iOS;
using Foundation;
using UIKit;

namespace EmpDirForms.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			Xamarin.FormsMaps.Init ();

			App.EmpDirClient = new EmployeeDirectory.EmployeeDirectoryClient(WorklightClient.CreateInstance());

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}


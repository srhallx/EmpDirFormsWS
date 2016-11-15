using System;
using EmployeeDirectory;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace EmpDirForms
{
	
	public class App : Application
	{

		public App ()
		{
			// The root page of your application
			//MainPage = new NavigationPage(new EmpDirList());
			CurrentPlatform.Init();
			MainPage = new NavigationPage(new EmpDirList());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}


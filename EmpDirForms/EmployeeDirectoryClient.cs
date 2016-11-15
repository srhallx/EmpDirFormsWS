using System;
using System.Net;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using System.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;

namespace EmployeeDirectory
{
	public class EmployeeDirectoryClient
	{
		
		private bool Connected { get; set; }

		public async Task<List<Employee>> GetAllEmployees()
		{
			var client = new MobileServiceClient("https://srhmobileapp.azurewebsites.net");


			var employeeData = await client.InvokeApiAsync<string>("Employees", System.Net.Http.HttpMethod.Get, null);

			return ParseEmployeeResultSet (employeeData);
		}

		public async Task<Location> GetLocation(string city)
		{
			var client = new HttpClient ();
			var geoData = await client.GetStringAsync ("https://maps.googleapis.com:443/maps/api/geocode/json?address='" + city + "'&sensor=false'");

			return ParseLocationResult (geoData);
		}

		protected List<Employee> ParseEmployeeResultSet(string data)
		{
			var parsedList = JsonConvert.DeserializeObject<EmployeeRoot> (data).rows;

			return parsedList;
		}

		protected Location ParseLocationResult(string data)
		{
			var loc = JsonConvert.DeserializeObject<GeoRoot> (data).results.First().geometry.location;
			return loc;
		}
	}
}


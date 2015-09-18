using System;
using System.Net;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using System.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace EmployeeDirectory
{
	public class EmployeeDirectoryClient
	{
		
		private bool Connected { get; set; }

		public async Task<List<Employee>> GetAllEmployees()
		{
			var client = new HttpClient ();
			var employeeData = await client.GetStringAsync ("https://srhallx.cloudant.com:443/employees/_design/employeeDesignDoc/_view/last?include_docs=true");

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

			//Just return the employee records
			return parsedList.Select (x => x.doc).ToList<Employee>();
		}

		protected Location ParseLocationResult(string data)
		{
			var loc = JsonConvert.DeserializeObject<GeoRoot> (data).results.First().geometry.location;
			return loc;
		}
	}
}


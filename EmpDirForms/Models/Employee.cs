using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace EmployeeDirectory
{

	public class Employee
	{
		public string _id { get; set; }
		public string _rev { get; set; }
		public string FullName { get; set; }
		public string Lastname { get; set; }
		public string Title { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string City { get; set; }
		public string Twitter { get; set; }
		public Location Loc { get; set; }

		public string Initials {
			get { 
				Regex initials = new Regex (@"(\b[a-zA-Z])[a-zA-Z]* ?");
				return initials.Replace (FullName, "$1");
			}
		}
	}

	public class EmployeeRow
	{
		public string id { get; set; }
		public string key { get; set; }
		public int value { get; set; }
		public Employee doc { get; set; }
	}

	public class EmployeeRoot
	{
		public int total_rows { get; set; }
		public int offset { get; set; }
		public List<EmployeeRow> rows { get; set; }
	}
}


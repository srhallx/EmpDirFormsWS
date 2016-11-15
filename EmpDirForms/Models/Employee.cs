using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace EmployeeDirectory
{

	public class Employee
	{
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

	public class EmployeeRoot
	{
		public List<Employee> rows { get; set; }
	}
}


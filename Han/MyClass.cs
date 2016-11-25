using System;
namespace Han
{
	public class User
	{
		public User()
		{
		}

		public string Name { get; set; }
		public string Description { get; set; }
		public string Password { get; set; }
	}

	public class MyLocation
	{
		public double Lat { get; set;}
		public double Lng { get; set;}
	}
}

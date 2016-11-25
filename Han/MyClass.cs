using System;
namespace Han
{
	public class Restaurant
	{
		public Restaurant()
		{
		}

		public string Name { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string Url { get; set;}
		public MyLocation DisplayLocation { get; set;}
	}

	public class MyLocation
	{
		public double Lat { get; set;}
		public double Lng { get; set;}
	}
}

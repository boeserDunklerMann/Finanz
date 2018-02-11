using System;

namespace DA.Finance.Home.Dto
{
	[Serializable]
	public sealed class Adresse 
	{
		public string Street { get; set; }
		public string Houseno { get; set; }
		public string Zip { get; set; }
		public string City { get; set; }
		public string CountryCode { get; set; }

	}
}

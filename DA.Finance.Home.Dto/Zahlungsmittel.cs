using System;
using System.Collections.Generic;

namespace DA.Finance.Home.Dto
{
	[Serializable]
	public sealed class Zahlungsmittel 
	{
		public Zahlungsmittel(string bezeichnung)
		{
			Bezeichnung = bezeichnung;
		}

		public string Bezeichnung { get; set; }
	}

	[Serializable]
	public sealed class Zahlungsmittels
	{
		public readonly List<Zahlungsmittel> zahlungsMittelList;
		public Zahlungsmittels()
		{
			zahlungsMittelList = new List<Zahlungsmittel>();
		}
	}
}

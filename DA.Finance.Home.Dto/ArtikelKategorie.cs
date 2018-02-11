using System;

namespace DA.Finance.Home.Dto
{
	[Serializable]
	public sealed class ArtikelKategorie 
	{
		public ArtikelKategorie(string bezeichnung)
		{
			Bezeichnung = bezeichnung;
		}

		public string Bezeichnung { get; set; }
	}
}

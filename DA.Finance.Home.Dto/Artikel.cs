using System;

namespace DA.Finance.Home.Dto
{
	[Serializable]
	public sealed class Artikel 
	{
		public string Bezeichnung { get; set; }
		public decimal PreisBrutto { get; set; }
		public ArtikelKategorie ArtikelKategorie { get; set; }
	}
}

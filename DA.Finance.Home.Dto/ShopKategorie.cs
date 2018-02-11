using System;

namespace DA.Finance.Home.Dto
{
	[Serializable]
	public sealed class ShopKategorie 
	{
		public ShopKategorie(string bezeichnung)
		{
			Bezeichnung = bezeichnung;
		}

		public string Bezeichnung { get; set; }
	}
}

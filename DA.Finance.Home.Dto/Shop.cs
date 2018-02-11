using System;

namespace DA.Finance.Home.Dto
{
	[Serializable]
	public sealed class Shop 
	{
		public Adresse Adresse{ get; set; }
		public ShopKategorie Kategorie { get; set; }
	}
}

using System;
using System.Collections.Generic;

namespace DA.Finance.Home.Dto
{
	[Serializable]
    public sealed class Einkauf 
    {
		public DateTime DatumUhrzeit { get; set; }
		public Shop Shop { get; set; }
		public readonly List<Tuple<int, Artikel>> anzahlArtikels;

		public Einkauf(DateTime datumUhrzeit, Shop shop)
		{
			DatumUhrzeit = datumUhrzeit;
			Shop = shop ?? throw new ArgumentNullException(nameof(shop));
			anzahlArtikels = new List<Tuple<int, Artikel>>();
		}
	}
}

using DA.Finance.Home.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DA.Finance.Home.IO.Serializer.JSON
{
	public sealed class JsonSerializer : Contracts.IFinanceSerializer
	{
		public ArtikelKategorien DeserializeArtikelKategorien(object serializedData)
			=> JsonConvert.DeserializeObject<ArtikelKategorien>(serializedData.ToString());

		public List<Einkauf> DeserializeEinkauf(object serializedData)
			=> JsonConvert.DeserializeObject<List<Einkauf>>(serializedData.ToString());

		public ShopKategorien DeserializeShopKategorien(object serializedData)
			=> JsonConvert.DeserializeObject<ShopKategorien>(serializedData.ToString());

		public Zahlungsmittels DeserializeZahlungsmittels(object serializedData)
			=> JsonConvert.DeserializeObject<Zahlungsmittels>(serializedData.ToString());

		public object SerializeArtikelKategorien(ArtikelKategorien artikelKategorien)
			=> JsonConvert.SerializeObject(artikelKategorien);

		public object SerializeEinkaufs(List<Einkauf> listEinkauf)
			=> JsonConvert.SerializeObject(listEinkauf);

		public object SerializeShopKategorien(ShopKategorien shopKategorien)
			=> JsonConvert.SerializeObject(shopKategorien);

		public object SerializeZahlungsmittels(Zahlungsmittels zahlungsmittels)
			=> JsonConvert.SerializeObject(zahlungsmittels);
	}
}

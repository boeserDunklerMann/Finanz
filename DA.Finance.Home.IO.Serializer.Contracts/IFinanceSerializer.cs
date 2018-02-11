using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Finance.Home.Dto;

namespace DA.Finance.Home.IO.Serializer.Contracts
{
    public interface IFinanceSerializer
    {
		/// <summary>
		/// Serialisiert alle Einkäufe
		/// </summary>
		/// <param name="listEinkauf">die Einkäufe</param>
		/// <returns>das serialisierte Objekt (bspw. JSON, XML)</returns>
		object SerializeEinkaufs(List<Einkauf> listEinkauf);

		/// <summary>
		/// Deserialisiert alle Einkäufe
		/// </summary>
		/// <param name="serializedData">das serialisierte Datenobjekt (JSON, XML)</param>
		/// <returns>die Einkäufe</returns>
		List<Einkauf> DeserializeEinkauf(object serializedData);

		object SerializeShopKategorien(ShopKategorien shopKategorien);
		ShopKategorien DeserializeShopKategorien(object serializedData);

		object SerializeArtikelKategorien(ArtikelKategorien artikelKategorien);
		ArtikelKategorien DeserializeArtikelKategorien(object serializedData);

		object SerializeZahlungsmittels(Zahlungsmittels zahlungsmittels);
		Zahlungsmittels DeserializeZahlungsmittels(object serializedData);
    }
}

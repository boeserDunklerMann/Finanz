using Commons = DA.Finance.Home.Commons;
using DA.Finance.Home.Dto;
using DA.Finance.Home.IO.Serializer.Contracts;
using DA.Finance.Home.IO.Storage.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSerializer
{
	class Program
	{
		static void Main(string[] args)
		{
			Zahlungsmittels zs = new Zahlungsmittels();
			zs.zahlungsMittelList.Add(new Zahlungsmittel("bar"));
			zs.zahlungsMittelList.Add(new Zahlungsmittel("EC/Maestro"));
			zs.zahlungsMittelList.Add(new Zahlungsmittel("Überweisung"));
			zs.zahlungsMittelList.Add(new Zahlungsmittel("Kreditkarte"));
			zs.zahlungsMittelList.Add(new Zahlungsmittel("guter Name :D"));
			ShopKategorien skn = new ShopKategorien();
			skn.Kategorien.Add(new ShopKategorie("Discounter"));
			skn.Kategorien.Add(new ShopKategorie("KNeipe"));
			skn.Kategorien.Add(new ShopKategorie("Online"));
			ArtikelKategorien akn = new ArtikelKategorien();
			akn.Kategorien.Add(new ArtikelKategorie("Essen"));
			akn.Kategorien.Add(new ArtikelKategorie("Katze"));
			akn.Kategorien.Add(new ArtikelKategorie("Sauferei/Spaß"));
			akn.Kategorien.Add(new ArtikelKategorie("Elektronik"));
			akn.Kategorien.Add(new ArtikelKategorie("Musik"));
			akn.Kategorien.Add(new ArtikelKategorie("Geschenk"));

			IFinanceSerializer ser = Commons.ContractBinder.GetObject<IFinanceSerializer>();
			var serZS = ser.SerializeZahlungsmittels(zs);
			var serSK = ser.SerializeShopKategorien(skn);
			var serAK = ser.SerializeArtikelKategorien(akn);

			Zahlungsmittels zs2 = ser.DeserializeZahlungsmittels(serZS);
			IDataAccessor data = Commons.ContractBinder.GetObject<IDataAccessor>();
			data.WriteZahlungsmittels(serZS.ToString());
			data.WriteShopKatekorien(serSK.ToString());
			data.WriteArtikelKategorien(serAK.ToString());

			Zahlungsmittels zs3 = ser.DeserializeZahlungsmittels(data.LoadZahlungsmittels());
		}
	}
}

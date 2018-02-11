using DA.Finance.Home.Dto;
using System.Collections.Generic;

namespace DA.Finance.Home.IO.Storage.Contracts
{
	/// <summary>
	/// Interface für Klassen, die auf Daten zugreifen (w/r) wollen
	/// </summary>
	public interface IDataAccessor
    {
		#region Meta
		/// <summary>
		/// die Datemverbindung, welche genutzt wird (Verzeichnis, ConnectionString)
		/// </summary>
		string ConnectedDatasource { get; }
		#endregion

		#region Einkäufe
		/// <summary>
		/// Lädt alle Einkäufe
		/// </summary>
		/// <returns>Serialisiertes Datenobjekt mit Einkäufen</returns>
		string LoadEinkaufs();
		void WriteEinkaufs(string data);
		#endregion

		#region Kategorien, Wertehilfen
		string LoadShopKategorien();
		void WriteShopKatekorien(string data);
		string LoadArtikelKategorien();
		void WriteArtikelKategorien(string data);
		string LoadZahlungsmittels();
		void WriteZahlungsmittels(string data);
		#endregion
	}
}

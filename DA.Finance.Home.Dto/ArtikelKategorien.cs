using System;
using System.Collections.Generic;

namespace DA.Finance.Home.Dto
{
	/// <summary>
	/// Speichert alle ArtikelKategorien, die möglich sind
	/// Nötig für ComboBoxen, ...
	/// </summary>
	[Serializable]
	public sealed class ArtikelKategorien
	{
		public readonly List<ArtikelKategorie> Kategorien;
		public ArtikelKategorien()
		{
			Kategorien = new List<ArtikelKategorie>();
		}
	}
}

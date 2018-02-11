using System;
using System.Collections.Generic;

namespace DA.Finance.Home.Dto
{
	/// <summary>
	/// Speichert alle ShopKategorien, die möglich sind
	/// Nötig für ComboBoxen, ...
	/// </summary>
	[Serializable]
	public sealed class ShopKategorien
	{
		public readonly List<ShopKategorie> Kategorien;
		public ShopKategorien()
		{
			Kategorien = new List<ShopKategorie>();
		}
	}
}

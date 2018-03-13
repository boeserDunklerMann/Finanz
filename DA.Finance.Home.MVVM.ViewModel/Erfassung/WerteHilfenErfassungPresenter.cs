using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DA.Finance.Home.MVVM.ViewModel.Erfassung
{
	public class WerteHilfenErfassungPresenter : PresenterBase
	{
		private Dto.Zahlungsmittels _zms;
		private Dto.ShopKategorien _shopKat;
		private Dto.ArtikelKategorien _artKat;

		public WerteHilfenErfassungPresenter() :base()
		{
			LoadZMS();
			LoadShopKat();
			LoadArtKat();
		}

		private void LoadArtKat() => _artKat = _serializer?.DeserializeArtikelKategorien(_storage?.LoadArtikelKategorien());

		private void LoadZMS() => _zms = _serializer?.DeserializeZahlungsmittels(_storage?.LoadZahlungsmittels());

		private void LoadShopKat() => _shopKat = _serializer?.DeserializeShopKategorien(_storage?.LoadShopKategorien());

		#region Lists for DGVs
		public ObservableCollection<Dto.Zahlungsmittel> ZMSList
		{
			get { return new ObservableCollection<Dto.Zahlungsmittel>(_zms?.zahlungsMittelList); }
		}

		public ObservableCollection<Dto.ShopKategorie> ShopKategorieList
		{
			get { return new ObservableCollection<Dto.ShopKategorie>(_shopKat?.Kategorien); }
		}

		public ObservableCollection<Dto.ArtikelKategorie> ArtikelKategorieList
		{
			get { return new ObservableCollection<Dto.ArtikelKategorie>(_artKat?.Kategorien); }
		}
		#endregion

		#region Commands
		public ICommand SaveZMSChanges
		{
			get { return new Framework.DelegateCommand(DoSaveZMSChanges); }
		}
		public ICommand DiscardZMSChanges
		{
			get { return new Framework.DelegateCommand(DoDiscardZMSChanges); }
		}
		public ICommand SaveShopKat
		{
			get { return new Framework.DelegateCommand(DoSaveShopKat); }
		}
		public ICommand DiscardShopKat
		{
			get { return new Framework.DelegateCommand(DoDiscardShopKat); }
		}
		public ICommand SaveArtKat
		{
			get { return new Framework.DelegateCommand(DoSaveArtKat); }
		}
		public ICommand DiscardArtKat
		{
			get { return new Framework.DelegateCommand(DoDiscardArtKat); }
		}
		public ICommand AddArtKat
		{
			get { return new Framework.DelegateCommand(DoAddArtKat); }
		}
		public ICommand AddShopKat
		{
			get { return new Framework.DelegateCommand(DoAddShopKat); }
		}
		public ICommand AddZMS
		{
			get { return new Framework.DelegateCommand(DoAddZMS); }
		}
		#endregion

		#region CommandActions
		private void DoDiscardZMSChanges() => LoadZMS();

		private void DoSaveZMSChanges()
		{
			var someJSONorXMLZMS = _serializer?.SerializeZahlungsmittels(_zms);
			_storage?.WriteZahlungsmittels(someJSONorXMLZMS?.ToString());
		}

		private void DoSaveShopKat()
		{
			var JsonShopKat = _serializer?.SerializeShopKategorien(_shopKat);
			_storage?.WriteShopKatekorien(JsonShopKat?.ToString());
		}
		private void DoDiscardShopKat() => LoadShopKat();

		private void DoSaveArtKat()
		{
			var JsonArtKat = _serializer?.SerializeArtikelKategorien(_artKat);
			_storage?.WriteArtikelKategorien(JsonArtKat?.ToString());
		}
		private void DoDiscardArtKat() => LoadArtKat();

		private void DoAddArtKat()
		{
			_artKat?.Kategorien.Add(new Dto.ArtikelKategorie(""));
			RaisePropertyChangedEvent("ArtikelKategorieList");
		}

		private void DoAddShopKat()
		{
			_shopKat?.Kategorien.Add(new Dto.ShopKategorie(""));
			RaisePropertyChangedEvent("ShopKategorieList");
		}

		private void DoAddZMS()
		{
			_zms?.zahlungsMittelList.Add(new Dto.Zahlungsmittel(""));
			RaisePropertyChangedEvent("ZMSList");
		}
		#endregion
	}
}

using DA.Finance.Home.IO.Serializer.Contracts;
using DA.Finance.Home.IO.Storage.Contracts;

namespace DA.Finance.Home.MVVM.ViewModel
{
	public abstract class PresenterBase : Framework.ObservableObject
	{
		protected readonly IFinanceSerializer _serializer;
		protected readonly IDataAccessor _storage;

		public PresenterBase()
		{
			_serializer = Commons.ContractBinder.GetObject<IFinanceSerializer>();
			_storage = Commons.ContractBinder.GetObject<IDataAccessor>();
		}
	}
}

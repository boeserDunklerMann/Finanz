using DA.Finance.Home.IO.Serializer.Contracts;
using DA.Finance.Home.IO.Serializer.JSON;
using DA.Finance.Home.IO.Storage.Contracts;
using DA.Finance.Home.IO.Storage.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Finance.Home.Commons
{
	/// <summary>
	/// Binds objects to contracts.
	/// </summary>
    public static class ContractBinder
    {
		private static HashSet<Tuple<Type, Type>> _container;
		private static int _nCounter = 0;
		
		static ContractBinder()
		{
			_container = new HashSet<Tuple<Type, Type>>();
		}

		private static void Bind(Type InterfaceType, Type ImplementationType)
		{
			// DONE: prüfen, dass es das Interface noch nicht im Container ist, das darfs ja nur einmal geben.
			Tuple<Type, Type> item = new Tuple<Type, Type>(InterfaceType, ImplementationType);
			_container.Add(item);
			_nCounter++;
		}

		public static void CreateBindings()
		{
			Bind(typeof(IFinanceSerializer), typeof(JsonSerializer));
			Bind(typeof(IDataAccessor), typeof(MySqlAccessor));
		}

		public static TInterface GetObject<TInterface>()
		{
			if (0 == _nCounter)
				CreateBindings();
			foreach(Tuple<Type, Type> bindings in _container)
			{
				if (bindings.Item1.Equals(typeof(TInterface)))
				{
					return (TInterface) Activator.CreateInstance(bindings.Item2);
				}
			}
			return default(TInterface);
		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Finance.Home.MVVM.Model
{
    public class PlaceAppLogicHere
    {
		private readonly Func<string, string> _func;
		public PlaceAppLogicHere(Func<string, string> func) => _func = func;

		public string DoAppLogic(string input) => _func(input);
	}
}

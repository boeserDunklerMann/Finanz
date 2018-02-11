using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DA.Finance.Home.MVVM.ViewModel
{
    public class Presenter : Framework.ObservableObject
    {
		private readonly Model.PlaceAppLogicHere _textConverter = new Model.PlaceAppLogicHere(s => s.ToUpper());
		private string _someText;
		private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

		public string SomeText
		{
			get { return _someText; }
			set
			{
				_someText = value;
				RaisePropertyChangedEvent(nameof(this.SomeText));
			}
		}

		public IEnumerable<string> History => _history;

		public ICommand DoAppLogicCommand
		{
			get { return new Framework.DelegateCommand(DoAppLogic); }
		}

		private void DoAppLogic()
		{
			if (string.IsNullOrWhiteSpace(SomeText)) return;
			AddToHistory(_textConverter.DoAppLogic(SomeText));
			SomeText = "";
		}

		private void AddToHistory(string item)
		{
			if (!_history.Contains(item))
				_history.Add(item);
		}
	}
}

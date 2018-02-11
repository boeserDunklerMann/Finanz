using System.ComponentModel;

namespace DA.Finance.Home.MVVM.Framework
{
	public abstract class ObservableObject : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChangedEvent(string propertyName) => 
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

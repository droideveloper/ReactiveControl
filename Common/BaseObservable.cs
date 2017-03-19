using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveWPFUserControl.Common {
	
	public abstract class BaseObservable: INotifyPropertyChanged {
		
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName) {
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected bool setProperty<T>(ref T propertyField, T propertyValue, [CallerMemberName] string propertyName = null) {
			if (EqualityComparer<T>.Default.Equals(propertyField, propertyValue)) {
				return false;
			}
			propertyField = propertyValue;
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}

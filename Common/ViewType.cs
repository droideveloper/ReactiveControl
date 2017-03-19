using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReactiveControls.Common {
	
	public interface ViewType {

		IObservable<RoutedEventArgs> Load { get; }
		IObservable<RoutedEventArgs> Unload {	get; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReactiveControls.Rx.Presentation {

	public static class TreeView_Extensions {
		
		public static IObservable<RoutedPropertyChangedEventArgs<object>> RxSelectedItemChanged<TSource>(this TSource ui) where TSource: TreeView {
			return Observable.FromEventPattern<RoutedPropertyChangedEventHandler<object>, RoutedPropertyChangedEventArgs<object>>(events => {
				ui.SelectedItemChanged += events;
			}, events => {
				ui.SelectedItemChanged -= events;
			}).Select(e => e.EventArgs);
		}
	}
}

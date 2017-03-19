using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class ListBoxItem_Extensions {		

		public static ControlProperty<bool> RxSelectedProperty<TSource>(this TSource ui) where TSource: ListBoxItem {
			var source = ui.RxSelected().Select(x => true);
			var bindingObserver = ui.RxIsSelected();
			return new ControlProperty<bool>(source, bindingObserver);
		}

		public static UIBindingObserver<TSource, bool> RxIsSelected<TSource>(this TSource ui) where TSource: ListBoxItem {
			return new UIBindingObserver<TSource, bool>(ui, (control, selected) => {
				control.IsSelected = selected;
			});
		}

		public static IObservable<RoutedEventArgs> RxSelected<TSource>(this TSource ui) where TSource: ListBoxItem {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Selected += events;
			}, events => {
				ui.Selected -= events;
			}).Select(e => e.EventArgs);
		}

		public static IObservable<RoutedEventArgs> RxUnselected<TSource>(this TSource ui) where TSource: ListBoxItem {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Unselected += events;
			}, events => {
				ui.Unselected -= events;
			}).Select(e => e.EventArgs);
		}
	}
}

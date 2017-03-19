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

	public static class Expander_Extensions {

		public static ControlProperty<bool> RxExpandedProperty<TSource>(this TSource ui) where TSource: Expander {
			var source = ui.RxExpanded().Select(x => true);
			var bindingObserver = ui.RxIsExpanded();
			return new ControlProperty<bool>(source, bindingObserver);
		}

		public static IObservable<RoutedEventArgs> RxExpanded<TSource>(this TSource ui) where TSource: Expander {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Expanded += events;
			}, events => {
				ui.Expanded -= events;
			}).Select(e => e.EventArgs);
		}

		public static IObservable<RoutedEventArgs> RxCollapsed<TSource>(this TSource ui) where TSource: Expander {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Collapsed += events;
			}, events => {
				ui.Collapsed -= events;
			}).Select(e => e.EventArgs);
		}

		public static UIBindingObserver<TSource, ExpandDirection> RxExpandDirection<TSource>(this TSource ui) where TSource: Expander {
			return new UIBindingObserver<TSource, ExpandDirection>(ui, (control, direction) => {
				control.ExpandDirection = direction;
			});
		}

		public static UIBindingObserver<TSource, bool> RxIsExpanded<TSource>(this TSource ui) where TSource: Expander {
			return new UIBindingObserver<TSource, bool>(ui, (control, expanded) => {
				control.IsExpanded = expanded;
			});
		}
	}
}

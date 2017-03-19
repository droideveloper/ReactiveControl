using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class Selector_Extensions {
		
		public static ControlProperty<int> RxSelectedIndexProperty<TSource>(this TSource ui) where TSource: Selector {
			var source = ui.RxSelectionChanged().Select(x => ui.SelectedIndex);
			var bindingObserver = ui.RxSelectedIndex();
			return new ControlProperty<int>(source, bindingObserver);
		}

		public static ControlProperty<object> RxSelectedItemProperty<TSource>(this TSource ui) where TSource: Selector {
			var source = ui.RxSelectionChanged().Select(x => ui.SelectedItem);
			var bindingObserver = ui.RxSelectedItem();
			return new ControlProperty<object>(source, bindingObserver);
		}

		public static ControlProperty<object> RxSelectedValueProperty<TSource>(this TSource ui) where TSource: Selector {
			var source = ui.RxSelectionChanged().Select(x => ui.SelectedValue);
			var bindingObserver = ui.RxSelectedValue();
			return new ControlProperty<object>(source, bindingObserver);
		}

		public static IObservable<SelectionChangedEventArgs> RxSelectionChanged<TSource>(this TSource ui) where TSource: Selector {
			return Observable.FromEventPattern<SelectionChangedEventHandler, SelectionChangedEventArgs>(events => {
				ui.SelectionChanged += events;
			}, events => {
				ui.SelectionChanged -= events;
			}).Select(e => e.EventArgs);		
		}

		public static UIBindingObserver<TSource, int> RxSelectedIndex<TSource>(this TSource ui) where TSource: Selector {
			return new UIBindingObserver<TSource, int>(ui, (control, index) => {
				control.SelectedIndex = index;
			});
		}

		public static UIBindingObserver<TSource, object> RxSelectedItem<TSource>(this TSource ui) where TSource: Selector {
			return new UIBindingObserver<TSource, object>(ui, (control, item) => {
				ui.SelectedItem = item;
			});
		}

		public static UIBindingObserver<TSource, object> RxSelectedValue<TSource>(this TSource ui) where TSource: Selector {
			return new UIBindingObserver<TSource, object>(ui, (control, value) => {
				ui.SelectedValue = value;
			});
		}
	}
}

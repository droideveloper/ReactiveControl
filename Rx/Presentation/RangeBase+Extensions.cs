using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace ReactiveControls.Rx.Presentation {

	public static class RangeBase_Extensions {

		public static ControlProperty<double> RxValueProperty<TSource>(this TSource ui) where TSource: RangeBase {
			var source = ui.RxValueChanged().Select(x => x.NewValue);
			var bindingObserver = ui.RxValue();
			return new ControlProperty<double>(source, bindingObserver);
		}

		public static IObservable<RoutedPropertyChangedEventArgs<double>> RxValueChanged<TSource>(this TSource ui) where TSource: RangeBase {
			return Observable.FromEventPattern<RoutedPropertyChangedEventHandler<double>, RoutedPropertyChangedEventArgs<double>>(events => {
				ui.ValueChanged += events;
			}, events => {
				ui.ValueChanged -= events;
			}).Select(e => e.EventArgs);
		}

		public static UIBindingObserver<TSource, double> RxValue<TSource>(this TSource ui) where TSource: RangeBase {
			return new UIBindingObserver<TSource, double>(ui, (control, value) => {
				control.Value = value;
			});
		}

		public static UIBindingObserver<TSource, double> RxMinimum<TSource>(this TSource ui) where TSource: RangeBase {
			return new UIBindingObserver<TSource, double>(ui, (control, min) => {
				control.Minimum = min;
			});
		}

		public static UIBindingObserver<TSource, double> RxMaximum<TSource>(this TSource ui) where TSource: RangeBase {
			return new UIBindingObserver<TSource, double>(ui, (control, max) => {
				control.Maximum = max;
			});
		}
	}
}

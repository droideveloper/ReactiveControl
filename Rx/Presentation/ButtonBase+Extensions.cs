using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ReactiveControls.Rx.Presentation {

	public static class ButtonBase_Extensions {

		public static UIBindingObserver<TSource, ClickMode> RxClickMode<TSource>(this TSource ui) where TSource: ButtonBase {
			return new UIBindingObserver<TSource, ClickMode>(ui, (control, mode) => {
				control.ClickMode = mode;
			});
		}

		public static IObservable<RoutedEventArgs> RxClick<TSource>(this TSource ui) where TSource: ButtonBase {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Click += events;
			}, events => {
				ui.Click -= events;
			}).Select(args => args.EventArgs);
		}
	}
}

using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReactiveControls.Rx.Presentation {
	
	public static class FrameworkElement_Extensions {

		public static UIBindingObserver<TSource, double> RxHeight<TSource>(this TSource ui) where TSource: FrameworkElement {
			return new UIBindingObserver<TSource, double>(ui, (control, height) => {
				control.Height = height;
			});
		}

		public static UIBindingObserver<TSource, double> RxWidth<TSource>(this TSource ui) where TSource: FrameworkElement {
			return new UIBindingObserver<TSource, double>(ui, (control, width) => {
				control.Width = width;
			});
		}

		public static UIBindingObserver<TSource, Thickness> RxMargin<TSource>(this TSource ui) where TSource: FrameworkElement {
			return new UIBindingObserver<TSource, Thickness>(ui, (control, ticknes) => {
				control.Margin = ticknes;
			});
		}

		public static UIBindingObserver<TSource, HorizontalAlignment> RxHorizontalAlignment<TSource>(this TSource ui) where TSource: FrameworkElement {
			return new UIBindingObserver<TSource, HorizontalAlignment>(ui, (control, hAlignment) => {
				control.HorizontalAlignment = hAlignment;
			});
		}

		public static UIBindingObserver<TSource, VerticalAlignment> RxVerticalAlignment<TSource>(this TSource ui) where TSource: FrameworkElement {
			return new UIBindingObserver<TSource, VerticalAlignment>(ui, (control, vAlignment) => {
				control.VerticalAlignment = vAlignment;
			});
		}

		public static IObservable<RoutedEventArgs> RxLoaded<TSource>(this TSource ui) where TSource: FrameworkElement {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Loaded += events;
			}, events => {
				ui.Loaded -= events;
			}).Select(args => args.EventArgs);
		}

		public static IObservable<RoutedEventArgs> RxUnloaded<TSource>(this TSource ui) where TSource: FrameworkElement {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Unloaded += events;
			}, events => {
				ui.Unloaded -= events;
			}).Select(args => args.EventArgs);
		}
	}
}

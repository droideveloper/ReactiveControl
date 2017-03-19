using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReactiveWPFUserControl.Rx.Presentation {
	
	public static class Control_Extensions {
	
		public static UIBindingObserver<TSource, double> RxFontSize<TSource>(this TSource ui) where TSource: Control {
			return new UIBindingObserver<TSource, double>(ui, (control, fontSize) => {
				control.FontSize = fontSize;
			});
		}	

		public static UIBindingObserver<TSource, Thickness> RxPadding<TSource>(this TSource ui) where TSource: Control {
			return new UIBindingObserver<TSource, Thickness>(ui, (control, padding) => {
				control.Padding = padding;
			});
		}

		public static IObservable<MouseButtonEventArgs> RxMouseDoubleClick<TSource>(this TSource ui) where TSource: Control {
			return Observable.FromEventPattern<MouseButtonEventHandler, MouseButtonEventArgs>(events => {
				ui.MouseDoubleClick += events;
			}, events => {
				ui.MouseDoubleClick -= events;
			}).Select(args => args.EventArgs);
		}
	}
}

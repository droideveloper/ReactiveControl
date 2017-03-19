using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReactiveControls.Rx.Presentation {

	public static class DatePicker_Extensions {
	
		public static UIBindingObserver<TSource, string> RxText<TSource>(this TSource ui) where TSource: DatePicker {
			return new UIBindingObserver<TSource, string>(ui, (control, text) => {
				control.Text = text;
			});
		}

		public static UIBindingObserver<TSource, DateTime> RxDisplayDate<TSource>(this TSource ui) where TSource: DatePicker {
			return new UIBindingObserver<TSource, DateTime>(ui, (control, date) => {
				control.DisplayDate = date;
			});
		}

		public static UIBindingObserver<TSource, DateTime> RxSelectedDate<TSource>(this TSource ui) where TSource: DatePicker {
			return new UIBindingObserver<TSource, DateTime>(ui, (control, date) => {
				control.SelectedDate = date;
			});
		}

		public static ControlProperty<DateTime> RxSelectedDateProperty<TSource>(this TSource ui) where TSource: DatePicker {
			var source = ui.RxSelectedDateChanged().Select(x => ui.SelectedDate ?? DateTime.Now);
			var bindingObserver = ui.RxSelectedDate();
			return new ControlProperty<DateTime>(source, bindingObserver);
		}

		public static IObservable<RoutedEventArgs> RxCalendarClosed<TSource>(this TSource ui) where TSource: DatePicker {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.CalendarClosed += events;
			}, events => {
				ui.CalendarClosed -= events;
			}).Select(e => e.EventArgs);
		}

		public static IObservable<RoutedEventArgs> RxCalendarOpened<TSource>(this TSource ui) where TSource: DatePicker {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.CalendarOpened += events;
			}, events => {
				ui.CalendarOpened -= events;
			}).Select(e => e.EventArgs);
		}

		public static IObservable<SelectionChangedEventArgs> RxSelectedDateChanged<TSource>(this TSource ui) where TSource: DatePicker {
			return Observable.FromEventPattern<SelectionChangedEventArgs>(events => {
				ui.SelectedDateChanged += events;
			}, events => {
				ui.SelectedDateChanged -= events;
			}).Select(e => e.EventArgs);
		}
	}
}

using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReactiveControls.Rx.Presentation {

	public static class Calendar_Extensions {

		public static IObservable<SelectionChangedEventArgs> RxSelectedDatesChanged<TSource>(this TSource ui) where TSource: Calendar {
			return Observable.FromEventPattern<SelectionChangedEventArgs>(events => {
				ui.SelectedDatesChanged += events;
			}, events => {
				ui.SelectedDatesChanged -= events;
			}).Select(e => e.EventArgs);
		}

		public static ControlProperty<DateTime> RxDisplayDateProperty<TSource>(this TSource ui) where TSource: Calendar {
			var source = ui.RxDisplayDateChanged();
			var bindingObserver = RxDisplayDate(ui);
			return new ControlProperty<DateTime>(source, bindingObserver);
		}

		public static IObservable<DateTime> RxDisplayDateChanged<TSource>(this TSource ui) where TSource: Calendar {
			return Observable.FromEventPattern<CalendarDateChangedEventArgs>(events => {
				ui.DisplayDateChanged += events;
			}, events => {
				ui.DisplayDateChanged -= events;
			}).Select(e => e.EventArgs.AddedDate ?? DateTime.Now);
		}

		public static UIBindingObserver<TSource, DateTime> RxDisplayDate<TSource>(this TSource ui) where TSource: Calendar {
			return new UIBindingObserver<TSource, DateTime>(ui, (control, date) => {
				control.DisplayDate = date;
			});
		}

		public static ControlProperty<CalendarMode> RxDisplayModeProperty<TSource>(this TSource ui) where TSource: Calendar {
			var source = ui.RxDisplayModeChanged();
			var bindingObserver = ui.RxDisplayMode();
			return new ControlProperty<CalendarMode>(source, bindingObserver);
		}

		public static IObservable<CalendarMode> RxDisplayModeChanged<TSource>(this TSource ui) where TSource: Calendar {
			return Observable.FromEventPattern<CalendarModeChangedEventArgs>(events => {
				ui.DisplayModeChanged += events;
			}, events => {
				ui.DisplayModeChanged -= events;
			}).Select(e => e.EventArgs.NewMode);
		}

		public static UIBindingObserver<TSource, CalendarMode> RxDisplayMode<TSource>(this TSource ui) where TSource: Calendar {
			return new UIBindingObserver<TSource, CalendarMode>(ui, (control, displayMode) => {
				control.DisplayMode = displayMode;
			});
		}

		public static ControlProperty<CalendarSelectionMode> RxSelectionModeProperty<TSource>(this TSource ui) where TSource: Calendar {
			var source = ui.RxSelectionModeChanged();
			var bindingObserver = RxSelectionMode(ui);
			return new ControlProperty<CalendarSelectionMode>(source, bindingObserver);
		}

		public static IObservable<CalendarSelectionMode> RxSelectionModeChanged<TSource>(this TSource ui) where TSource: Calendar {
			return Observable.FromEventPattern<EventArgs>(events => {
				ui.SelectionModeChanged += events;
			}, events => {
				ui.SelectionModeChanged -= events;
			}).Select(e => ui.SelectionMode);
		}

		public static UIBindingObserver<TSource, CalendarSelectionMode> RxSelectionMode<TSource>(this TSource ui) where TSource: Calendar {
			return new UIBindingObserver<TSource, CalendarSelectionMode>(ui, (control, mode) => {
				control.SelectionMode = mode;
			});
		}
	}
}

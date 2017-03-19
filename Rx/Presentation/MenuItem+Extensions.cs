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
	
	public static class MenuItem_Extensions {
	
		public static UIBindingObserver<TSource, bool> RxIsChecked<TSource>(this TSource ui) where TSource: MenuItem {
			return new UIBindingObserver<TSource, bool>(ui, (control, check) => {
				control.IsChecked = check;
			});
		}

		public static UIBindingObserver<TSource, bool> RxIsCheckable<TSource>(this TSource ui) where TSource: MenuItem {
			return new UIBindingObserver<TSource, bool>(ui, (control, checkable) => {
				control.IsCheckable = checkable;
			});
		}

		public static UIBindingObserver<TSource, bool> RxIsSubmenuOpen<TSource>(this TSource ui) where TSource: MenuItem {
			return new UIBindingObserver<TSource, bool>(ui, (control, open) => {
				control.IsSubmenuOpen = open;
			});
		}

		public static IObservable<RoutedEventArgs> RxUnchecked<TSource>(this TSource ui) where TSource: MenuItem {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Unchecked += events;
			}, events => {
				ui.Unchecked -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<RoutedEventArgs> RxChecked<TSource>(this TSource ui) where TSource: MenuItem {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Checked += events;
			}, events => {
				ui.Checked -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<RoutedEventArgs> RxClick<TSource>(this TSource ui) where TSource: MenuItem {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.Click += events;
			}, events => {
				ui.Click -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<RoutedEventArgs> RxSubmenuClosed<TSource>(this TSource ui) where TSource: MenuItem {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.SubmenuClosed += events;
			}, events => {
				ui.SubmenuClosed -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<RoutedEventArgs> RxSubmenuOpened<TSource>(this TSource ui) where TSource: MenuItem {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.SubmenuOpened += events;
			}, events => {
				ui.SubmenuOpened -= events;
			}).Select(x => x.EventArgs);
		}
	}
}

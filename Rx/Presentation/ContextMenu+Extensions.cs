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
	
	public static class ContextMenu_Extensions {
	
			public static IObservable<RoutedEventArgs> RxOpened<TSource>(this TSource ui) where TSource: ContextMenu	 {
				return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
					ui.Opened += events;
				}, events => {
					ui.Opened -= events;
				}).Select(e => e.EventArgs);
			}

			public static IObservable<RoutedEventArgs> RxClosed<TSource>(this TSource ui) where TSource: ContextMenu {
				return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
					ui.Closed += events;
				}, events => {
					ui.Closed -= events;
				}).Select(e => e.EventArgs);
			}

			public static UIBindingObserver<TSource, bool> RxIsOpen<TSource>(this TSource ui) where TSource: ContextMenu {
				return new UIBindingObserver<TSource, bool>(ui, (control, open) => {
					control.IsOpen = open;
				});
			}
	
	}
}

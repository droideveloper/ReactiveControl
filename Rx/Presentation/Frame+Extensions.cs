using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ReactiveControls.Rx.Presentation {

	public static class Frame_Extensions {
		
		public static IObservable<EventArgs> RxContentRendered<TSource>(this TSource ui) where TSource: Frame {
			return Observable.FromEventPattern<EventHandler, EventArgs>(events => {
				ui.ContentRendered += events;
			}, events => {
				ui.ContentRendered -= events;
			}).Select(e => e.EventArgs);
		}

		public static IObservable<NavigationEventArgs> RxLoadCompleted<TSource>(this TSource ui) where TSource: Frame {
			return Observable.FromEventPattern<LoadCompletedEventHandler, NavigationEventArgs>(events => {
				ui.LoadCompleted += events;
			}, events => {
				ui.LoadCompleted -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<FragmentNavigationEventArgs> RxFramentNavigation<TSource>(this TSource ui) where TSource: Frame {
			return Observable.FromEventPattern<FragmentNavigationEventHandler, FragmentNavigationEventArgs>(events => {
				ui.FragmentNavigation += events;
			}, events => {
				ui.FragmentNavigation -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<NavigationEventArgs> RxNavigated<TSource>(this TSource ui) where TSource: Frame {
			return Observable.FromEventPattern<NavigatedEventHandler, NavigationEventArgs>(events => {
				ui.Navigated += events;
			}, events => {
				ui.Navigated -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<NavigatingCancelEventArgs> RxNavigating<TSource>(this TSource ui) where TSource: Frame {
			return Observable.FromEventPattern<NavigatingCancelEventHandler, NavigatingCancelEventArgs>(events => {
				ui.Navigating += events;
			}, events => {
				ui.Navigating -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<NavigationFailedEventArgs> RxNavigationFailed<TSource>(this TSource ui) where TSource: Frame {
			return Observable.FromEventPattern<NavigationFailedEventHandler, NavigationFailedEventArgs>(events => {
				ui.NavigationFailed += events;
			}, events => {
				ui.NavigationFailed -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<NavigationProgressEventArgs> RxNavigationProgress<TSource>(this TSource ui) where TSource: Frame {
			return Observable.FromEventPattern<NavigationProgressEventHandler, NavigationProgressEventArgs>(events => {
				ui.NavigationProgress += events;
			}, events => {
				ui.NavigationProgress -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<NavigationEventArgs> RxNavigationStopped<TSource>(this TSource ui) where TSource: Frame {
			return Observable.FromEventPattern<NavigationStoppedEventHandler, NavigationEventArgs>(events => {
				ui.NavigationStopped += events;
			}, events => {
				ui.NavigationStopped -= events;
			}).Select(x => x.EventArgs);
		}
	}
}

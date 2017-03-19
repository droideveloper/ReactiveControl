using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reactive.Linq;
using System.Reactive.Threading;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace ReactiveControls.Rx {

	public static class Extensions {

		public static IDisposable BindTo<TSource>(this IObservable<TSource> source, IObserver<TSource> observer) {
			return source
				.ObserveOnDispatcher(DispatcherPriority.Render)
				.Subscribe(observer);
		}

		public static IDisposable BindNext<TSource>(this IObservable<TSource> source, Action<TSource> bindNext) {
			return source
				.ObserveOnDispatcher(DispatcherPriority.Render)
				.Subscribe(bindNext);
		}

		public static void DisposeBy(this IDisposable source, DisposeBag dispose) {
			dispose.AddDisposable(source);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reactive.Linq;
using System.Reactive.Linq;
using System.Windows.Threading;
using System.Reactive.Concurrency;

namespace ReactiveControls.Rx {

	public static class Extensions {

		public static IObservable<TSource> Async<TSource>(this IObservable<TSource> source) {
			return source.SubscribeOn(TaskPoolScheduler.Default)
				.ObserveOnDispatcher(DispatcherPriority.Render);
		}

		public static IDisposable BindTo<TSource>(this IObservable<TSource> source, IObserver<TSource> observer) {
			return source.Subscribe(observer);
		}

		public static IDisposable BindNext<TSource>(this IObservable<TSource> source, Action<TSource> bindNext) {
			return source.Subscribe(bindNext);
		}

		public static void DisposeBy(this IDisposable source, DisposeBag disposes) {
			if (disposes == null) {
				throw new ArgumentNullException("disposes can not be null");
			} 
			disposes.Add(source);
		}
	}
}

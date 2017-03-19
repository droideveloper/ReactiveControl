using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reactive.Linq;
using System.Windows.Controls.Primitives;

namespace ReactiveControls.Rx {

	public static class Extensions {

		public static IDisposable BindTo<TSource>(this IObservable<TSource> source, IObserver<TSource> observer) {
			return source.Subscribe(observer);
		}

		public static IDisposable BindNext<TSource>(this IObservable<TSource> source, Action<TSource> bindNext) {
			return source.Subscribe(bindNext);
		}

		public static void DisposeBy(this IDisposable source, DisposeBag dispose) {
			dispose.AddDisposable(source);
		}
	}
}

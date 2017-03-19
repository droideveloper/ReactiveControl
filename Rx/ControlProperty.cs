using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Threading;
using System.Windows.Threading;

namespace ReactiveControls.Rx {

	public sealed class ControlProperty<TSource>: IObserver<TSource>, IObservable<TSource> {

		public ControlEvent<TSource> Changed {
			get {
				return new ControlEvent<TSource>(values.Skip(1));
			}
		}

		private readonly IObservable<TSource> values;
		private readonly IObserver<TSource> valueSink;
		
		public ControlProperty(IObservable<TSource> values, IObserver<TSource> valueSink) {
			this.values = values.SubscribeOnDispatcher(DispatcherPriority.Render);
			this.valueSink = valueSink;
		}

		public void OnCompleted() {
			valueSink.OnCompleted();
		}

		public void OnError(Exception error) {
			throw error;
		}

		public void OnNext(TSource value) {
			valueSink.OnNext(value);
		}

		public IDisposable Subscribe(IObserver<TSource> observer) {
			return values.Subscribe(observer);
		}

		public IObservable<TSource> AsObservable() {
			return values;
		}

		public ControlProperty<TSource> AsControlProperty() {
			return this;
		}
	}
}

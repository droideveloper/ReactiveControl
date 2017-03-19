using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

namespace ReactiveControls.Rx {
	
	public sealed class ControlEvent<TSource>: IObservable<TSource> {

		private readonly IObservable<TSource> events;

		public ControlEvent(IObservable<TSource> events) {
			this.events = events.SubscribeOn(CurrentThreadScheduler.Instance);
		}

		public IDisposable Subscribe(IObserver<TSource> observer) {
			return events.Subscribe(observer);
		}

		public IObservable<TSource> AsObservable() {
			return events;
		}

		public ControlEvent<TSource> AsControlEvent() {
			return this;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace ReactiveWPFUserControl.Common {
		
	public sealed class BusManager {

		private readonly Subject<EventType> RxBus = new Subject<EventType>();
		private static readonly BusManager IMPL = new BusManager();

		private BusManager() {}

		IDisposable Register(Action<EventType> onNext) {
			return RxBus.Subscribe(onNext);
		}

		void Post<TSource>(TSource e) where TSource: EventType {
			RxBus.OnNext(e);
		}

		public static IDisposable Add(Action<EventType> onNext) {
			return IMPL.Register(onNext);
		}

		public static void Send<TSource>(TSource e) where TSource: EventType {
			IMPL.Post<TSource>(e);
		}
	}
}

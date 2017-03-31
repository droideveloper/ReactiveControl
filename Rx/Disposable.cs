using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;

namespace ReactiveControls.Rx {

	public sealed class Disposable {

		public readonly ReplaySubject<Disposable> DestroyedSink = new ReplaySubject<Disposable>(1);
	
		~Disposable() {
			DestroyedSink.OnNext(this);
			DestroyedSink.OnCompleted();
		}
	}
}

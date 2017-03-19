using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;

namespace ReactiveControls.Rx {

	public sealed class Destructable {

		public readonly ReplaySubject<Destructable> DestroyedSink = new ReplaySubject<Destructable>(1);
	
		~Destructable() {
			DestroyedSink.OnNext(this);
			DestroyedSink.OnCompleted();
		}
	}
}

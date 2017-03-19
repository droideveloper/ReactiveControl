using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;

namespace ReactiveControls.Rx {

    public sealed class Variable<TSource> {

			private readonly BehaviorSubject<TSource> valueSink;

			private TSource value;

			public TSource Value {
				get {
					return value;
				}
				set {
					this.value = value;
					valueSink.OnNext(value);
				}
			}

			public Variable(TSource value) {
				this.value = value;
				this.valueSink = new BehaviorSubject<TSource>(value);
			}

			public IObservable<TSource> AsObservable() {
				return valueSink;
			}

			~Variable() {
			  valueSink.OnCompleted();
			}
		}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveControls.Rx {

	public sealed class UIBindingObserver<UIControl, TSource>: IObserver<TSource> {

		private readonly UIControl control;
		private readonly Action<UIControl, TSource> binding;

		public UIBindingObserver(UIControl control, Action<UIControl, TSource> binding) {
			this.control = control;
			this.binding = binding;
		}

		public void OnCompleted() { /*No-Ops*/ 	}

		public void OnError(Exception error) {
			throw error;
		}

		public void OnNext(TSource value) {
			binding(control, value);
		}

		public IObserver<TSource> AsObserver() {
			return this;
		}
	}
}

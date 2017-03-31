using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ReactiveControls.Rx {

	public sealed class UIBindingObserver<UIControl, TSource>: IObserver<TSource> {

		private readonly UIControl control;
		private readonly Action<UIControl, TSource> binding;

		public UIBindingObserver(UIControl control, Action<UIControl, TSource> binding) {
			if (control == null) {
				throw new ArgumentNullException("control can not be null");
			}
			if (binding == null) {
				throw new ArgumentNullException("binding can not be null");	
			}
			this.control = control;
			this.binding = binding;
		}

		public void OnCompleted() { /*No-Ops*/ 	}

		public void OnError(Exception error) {
			throw error;
		}

		public void OnNext(TSource value) {
			Dispatcher currentDispatcher = Dispatcher.FromThread(Thread.CurrentThread);
			Dispatcher mainDispatcher = Application.Current.Dispatcher;
			if (currentDispatcher != mainDispatcher) {
				mainDispatcher.BeginInvoke(() => {
					OnNext(value);
				});
			} else {
				binding(control, value);
			}			
		}

		public IObserver<TSource> AsObserver() {
			return this;
		}
	}
}

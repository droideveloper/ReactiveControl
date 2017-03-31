using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive.Disposables;
using System.Threading.Tasks;

namespace ReactiveControls.Rx {
	
	public sealed class DisposeBag {

		private readonly CompositeDisposable disposes = new CompositeDisposable();

		public void Add(IDisposable dispose) {
			if (dispose != null && !disposes.Contains(dispose)) {
				disposes.Add(dispose);
			}
		}

		~DisposeBag() {
			if (!disposes.IsDisposed) {
				disposes.Clear();
				disposes.Dispose();
			}
		}
	}
}

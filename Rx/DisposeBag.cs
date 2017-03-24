using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveControls.Rx {
	
	public sealed class DisposeBag {

		private readonly CompositeDisposable disposeCollection = new CompositeDisposable();

		public void AddDisposable(IDisposable disposable) {
			disposeCollection.Add(disposable);
		}

		~DisposeBag() {
			disposeCollection.Clear();
			if(!disposeCollection.IsDisposed) {
				disposeCollection.Dispose();
			}
		}
	}
}

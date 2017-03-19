using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveControls.Rx {
	
	public sealed class DisposeBag {

		private readonly List<IDisposable> disposeCollection = new List<IDisposable>();
	
		public void AddDisposable(IDisposable disposable) {
			disposeCollection.Add(disposable);
		}

		~DisposeBag() {
			disposeCollection.ForEach(x => x.Dispose());
			disposeCollection.Clear();
		}
	}
}

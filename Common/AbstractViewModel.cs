using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReactiveWPFUserControl.Common {

	public abstract class AbstractViewModel<TSource>: BaseObservable where TSource: ViewType {
		
		protected readonly DisposeBag dispose = new DisposeBag();
		protected readonly TSource view;

		public AbstractViewModel(TSource view) {
			this.view = view;
			this.view.Load
				.BindNext(x => OnStart())
				.DisposeBy(dispose);
			this.view.Unload
				.BindNext(x => OnStop())
				.DisposeBy(dispose);
		}

		protected abstract void OnStart();
		protected abstract void OnStop();
	}
}

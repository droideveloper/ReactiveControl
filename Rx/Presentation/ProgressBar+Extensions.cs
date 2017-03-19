using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class ProgressBar_Extensions {
	
		public static UIBindingObserver<TSource, bool> RxIsIndeterminate<TSource>(this TSource ui) where TSource: ProgressBar {
			return new UIBindingObserver<TSource, bool>(ui, (control, indeterminate) => {
				control.IsIndeterminate = indeterminate;
			});
		}

		public static UIBindingObserver<TSource, Orientation> RxOrientation<TSource>(this TSource ui) where TSource: ProgressBar {
			return new UIBindingObserver<TSource, Orientation>(ui, (control, orientation) => {
				control.Orientation = orientation;
			});
		}
	}
}

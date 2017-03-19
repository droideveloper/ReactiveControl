using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReactiveWPFUserControl.Rx.Presentation {
	
	public static class StackPanel_Extensions {
	
		public static UIBindingObserver<TSource, Orientation> RxOrientation<TSource>(this TSource ui) where TSource: StackPanel {
			return new UIBindingObserver<TSource, Orientation>(ui, (control, orientation) => {
				control.Orientation = orientation;
			});
		}

		public static UIBindingObserver<TSource, bool> RxVerticallyScroll<TSource>(this TSource ui) where TSource: StackPanel {
			return new UIBindingObserver<TSource, bool>(ui, (control, verticalScroll) => {
				control.CanVerticallyScroll = verticalScroll;
			});
		}

		public static UIBindingObserver<TSource, bool> RxHorizontallyScroll<TSource>(this TSource ui) where TSource: StackPanel {
			return new UIBindingObserver<TSource, bool>(ui, (control, horizontalScroll) => {
				control.CanHorizontallyScroll = horizontalScroll;
			});
		}
	}
}

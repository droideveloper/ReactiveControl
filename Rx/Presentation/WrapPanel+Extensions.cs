using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReactiveControls.Rx.Presentation {

	public static class WrapPanel_Extensions {

		public static UIBindingObserver<TSource, double> RxItemHeight<TSource>(this TSource ui) where TSource: WrapPanel {
			return new UIBindingObserver<TSource, double>(ui, (control, height) => {
				control.ItemHeight = height;
			});
		}

		public static UIBindingObserver<TSource, double> RxItemWidth<TSource>(this TSource ui) where TSource: WrapPanel {
			return new UIBindingObserver<TSource, double>(ui, (control, width) => {
				control.ItemWidth = width;
			});
		}

		public static UIBindingObserver<TSource, Orientation> RxOrientation<TSource>(this TSource ui) where TSource: WrapPanel {
			return new UIBindingObserver<TSource, Orientation>(ui, (control, orientation) => {
				control.Orientation = orientation;
			});
		}
	}
}

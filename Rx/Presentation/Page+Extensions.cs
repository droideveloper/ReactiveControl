using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class Page_Extensions {
	
		public static UIBindingObserver<TSource, string> RxTitle<TSource>(this TSource ui) where TSource: Page {
			return new UIBindingObserver<TSource, string>(ui, (control, title) => {
				control.Title = title;
			});
		}

		public static UIBindingObserver<TSource, string> RxWindowTitle<TSource>(this TSource ui) where TSource: Page {
			return new UIBindingObserver<TSource, string>(ui, (control, title) => {
				control.WindowTitle = title;
			});
		}

		public static UIBindingObserver<TSource, double> RxWindowWidth<TSource>(this TSource ui) where TSource: Page {
			return new UIBindingObserver<TSource, double>(ui, (control, width) => {
				control.WindowWidth = width;
			});
		}

		public static UIBindingObserver<TSource, double> RxWindowHeight<TSource>(this TSource ui) where TSource: Page {
			return new UIBindingObserver<TSource, double>(ui, (control, height) => {
				control.WindowHeight = height;
			});
		}
	}
}

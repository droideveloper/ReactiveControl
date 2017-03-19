using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class ContentControl_Extensions {
	
		public static UIBindingObserver<TSource, object> RxContent<TSource>(this TSource ui) where TSource: ContentControl {
			return new UIBindingObserver<TSource, object>(ui, (control, content) => {
				control.Content = content;
			});
		}
	}
}

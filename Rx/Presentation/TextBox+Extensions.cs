using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class TextBox_Extensions {
		
		public static UIBindingObserver<TSource, string> RxText<TSource>(this TSource ui) where TSource: TextBox {
			return new UIBindingObserver<TSource, string>(ui, (control, text) => {
				control.Text = text;
			});
		}

	}

}

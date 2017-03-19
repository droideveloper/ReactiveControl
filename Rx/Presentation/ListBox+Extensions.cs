using ReactiveControls.Rx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReactiveControls.Rx.Presentation {
	
	public static class ListBox_Extensions {
	
		public static UIBindingObserver<TSource, IList> RxSelectedItems<TSource>(this TSource ui) where TSource: ListBox {
			return new UIBindingObserver<TSource, IList>(ui, (control, items) => {
				foreach(var item in items) {
					control.SelectedItems.Add(item);
				}
			});
		}

		public static UIBindingObserver<TSource, SelectionMode> RxSelectionMode<TSource>(this TSource ui) where TSource: ListBox {
			return new UIBindingObserver<TSource, SelectionMode>(ui, (control, mode) => {
				control.SelectionMode = mode;
			});
		}
	}
}

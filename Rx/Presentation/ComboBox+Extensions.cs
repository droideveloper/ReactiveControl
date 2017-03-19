using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReactiveWPFUserControl.Rx.Presentation {
	
	public static class ComboBox_Extensions {

		public static IObservable<EventArgs> RxDropDownClosed<TSource>(this TSource ui) where TSource: ComboBox {
			return Observable.FromEventPattern<EventHandler, EventArgs>(events => {
				ui.DropDownClosed += events;
			}, events => {
				ui.DropDownClosed -= events;
			}).Select(x => x.EventArgs);
		}

		public static IObservable<EventArgs> RxDropDownOpened<TSource>(this TSource ui) where TSource: ComboBox {
			return Observable.FromEventPattern<EventHandler, EventArgs>(events => {
				ui.DropDownOpened += events;
			}, events => {
				ui.DropDownOpened -= events;
			}).Select(x => x.EventArgs);
		}

		public static UIBindingObserver<TSource, bool> RxIsEditable<TSource>(this TSource ui) where TSource: ComboBox {
			return new UIBindingObserver<TSource, bool>(ui, (control, editable) => {
				control.IsEditable = editable;
			});
		}

		public static UIBindingObserver<TSource, string> RxText<TSource>(this TSource ui) where TSource: ComboBox {
			return new UIBindingObserver<TSource, string>(ui, (control, text) => {
				control.Text = text;
			});
		}
	}
}

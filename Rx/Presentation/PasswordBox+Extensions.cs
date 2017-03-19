using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class PasswordBox_Extensions {

		public static ControlProperty<string> RxPasswordProperty(this PasswordBox ui) {
			var source = ui.RxPasswordChanged().Select(x => ui.Password);
			var bindingObserver = ui.RxPassword();
			return new ControlProperty<string>(source, bindingObserver);				
		}

		public static IObservable<RoutedEventArgs> RxPasswordChanged(this PasswordBox ui) {
			return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(events => {
				ui.PasswordChanged += events;
			}, events => {
				ui.PasswordChanged -= events;
			}).Select(e => e.EventArgs);
		}

		public static UIBindingObserver<PasswordBox, string> RxPassword(this PasswordBox ui) {
			return new UIBindingObserver<PasswordBox, string>(ui, (control, password) => {
				control.Password = password;
			});
		}

		public static UIBindingObserver<PasswordBox, char> RxPasswordChar(this PasswordBox ui) {
			return new UIBindingObserver<PasswordBox, char>(ui, (control, hide) => {
				control.PasswordChar = hide;
			});
		}
	}
}

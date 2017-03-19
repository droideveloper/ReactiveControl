using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveControls.Rx;
using System.Windows;
using System.Reactive.Linq;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class UIElement_Extensions {

		public static UIBindingObserver<TSource, bool> RxAllowDrop<TSource>(this TSource ui) where TSource: UIElement {
			return new UIBindingObserver<TSource, bool>(ui, (control, allowDrop) => {
				control.AllowDrop = allowDrop;
			});
		}

		public static UIBindingObserver<TSource, double> RxOpacity<TSource>(this TSource ui) where TSource: UIElement {
			return new UIBindingObserver<TSource, double>(ui, (control, opacity) => {
				control.Opacity = opacity;
			});
		}

		public static ControlProperty<bool> RxFocusableProperty<TSource>(this TSource ui) where TSource: UIElement {
			var source = ui.RxFocusableChanged();
			var bindingObserver = ui.RxFocusable();
			return new ControlProperty<bool>(source, bindingObserver);
		}

		public static IObservable<bool> RxFocusableChanged<TSource>(this TSource ui) where TSource: UIElement {
			return Observable.FromEventPattern<DependencyPropertyChangedEventHandler, DependencyPropertyChangedEventArgs>(events => {
				ui.FocusableChanged += events;
			}, events => {
				ui.FocusableChanged -= events;
			}).Select(e => (bool)e.EventArgs.NewValue);
		}

		public static UIBindingObserver<TSource, bool> RxFocusable<TSource>(this TSource ui) where TSource: UIElement {
			return new UIBindingObserver<TSource, bool>(ui, (control, focusable) => {
				control.Focusable = focusable;	
			});
		}

		public static ControlProperty<bool> RxIsEnabledProperty<TSource>(this TSource ui) where TSource: UIElement {
			var source = ui.RxIsEnabledChanged();
			var bindingObserver = ui.RxIsEnabled();
			return new ControlProperty<bool>(source, bindingObserver);
		}

		public static IObservable<bool> RxIsEnabledChanged<TSource>(this TSource ui) where TSource: UIElement {
			return Observable.FromEventPattern<DependencyPropertyChangedEventHandler, DependencyPropertyChangedEventArgs>(events => {
				ui.IsEnabledChanged += events;
			}, events => {
				ui.IsEnabledChanged -= events;
			}).Select(e => (bool)e.EventArgs.NewValue);
		}

		public static UIBindingObserver<TSource, bool> RxIsEnabled<TSource>(this TSource ui) where TSource: UIElement {
			return new UIBindingObserver<TSource, bool>(ui, (control, enabled) => {
				control.IsEnabled = enabled;
			});
		}

		public static ControlProperty<Visibility> RxVisibilityProperty<TSource>(this TSource ui) where TSource: UIElement {
			var source = ui.RxVisibilityChanged();
			var bindingObserver = ui.RxVisibility();
			return new ControlProperty<Visibility>(source, bindingObserver);
		}

		public static IObservable<Visibility> RxVisibilityChanged<TSource>(this TSource ui) where TSource: UIElement {
			return Observable.FromEventPattern<DependencyPropertyChangedEventHandler, DependencyPropertyChangedEventArgs>(events => {
				ui.IsVisibleChanged += events;
			}, events => {
				ui.IsVisibleChanged -= events;
			})
			.Select(e => (Visibility)e.EventArgs.NewValue);
		}

		public static UIBindingObserver<TSource, Visibility> RxVisibility<TSource>(this TSource ui) where TSource: UIElement {
			return new UIBindingObserver<TSource, Visibility>(ui, (control, visibility) => {
				control.Visibility = visibility;
			});
		}
	}
}

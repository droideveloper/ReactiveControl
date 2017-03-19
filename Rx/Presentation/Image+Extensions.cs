using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class Image_Extensions {

		public static UIBindingObserver<TSource, ImageSource> RxSource<TSource>(this TSource ui) where TSource: Image {
			return new UIBindingObserver<TSource, ImageSource>(ui, (control, source) => {
				control.Source = source;
			});
		}

		public static UIBindingObserver<TSource, Stretch> RxStretch<TSource>(this TSource ui) where TSource: Image {
			return new UIBindingObserver<TSource, Stretch>(ui, (control, stretch) => {
				control.Stretch = stretch;
			});
		}

		public static UIBindingObserver<TSource, StretchDirection> RxStretchDirection<TSource>(this TSource ui) where TSource: Image {
			return new UIBindingObserver<TSource, StretchDirection>(ui, (control, direction) => {
				control.StretchDirection = direction;
			});
		}
	}
}

using ReactiveControls.Rx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ReactiveWPFUserControl.Rx.Presentation {

	public static class TextBox_Extensions {
		
		public static UIBindingObserver<TSource, string> RxText<TSource>(this TSource ui) where TSource: TextBox {
			return new UIBindingObserver<TSource, string>(ui, (control, text) => {
				control.Text = text;
			});
		}

		public static UIBindingObserver<TSource, TextAlignment> RxTextAlignment<TSource>(this TSource ui) where TSource: TextBox {
			return new UIBindingObserver<TSource, TextAlignment>(ui, (control, alignment) => {
				control.TextAlignment = alignment;
			});
		}

		public static UIBindingObserver<TSource, CharacterCasing> RxCharacterCasing<TSource>(this TSource ui) where TSource: TextBox {
			return new UIBindingObserver<TSource, CharacterCasing>(ui, (control, casing) => {
				control.CharacterCasing = casing;
			});
		}

		public static UIBindingObserver<TSource, int> RxMinLines<TSource>(this TSource ui) where TSource: TextBox {
			return new UIBindingObserver<TSource, int>(ui, (control, minLines) => {
				control.MinLines = minLines;
			});
		}

		public static UIBindingObserver<TSource, int> RxMaxLines<TSource>(this TSource ui) where TSource: TextBox {
			return new UIBindingObserver<TSource, int>(ui, (control, maxLines) => {
				control.MaxLines = maxLines;
			});
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveControls.Common {

	public sealed class BuildConfig {
	#if DEBUG
		public readonly static bool DEBUG = true;
	#else
		public readonly static bool DEBUG = false;
	#endif
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace ReactiveControls.Net {
	
	public sealed class HttpResponse<TSource> {

		public TSource Content;
		public HttpStatusCode Code;
		public string ReasonPhrase;

	}
}

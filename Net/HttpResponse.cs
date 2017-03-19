using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace ReactiveControls.Net {
	
	public sealed class HttpResponse<T> {

		public HttpStatusCode StatusCode {	get; set;	}
		public T DataSet { get; set; }
		public string Reason { get; set; }

		public bool IsSuccess {
			get {
				return StatusCode == HttpStatusCode.OK;
			}
		}
	}
}

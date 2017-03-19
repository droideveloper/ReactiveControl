using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace ReactiveWPFUserControl.Net {
	
	public static class Extensions {

		public static IObservable<HttpResponse<TSource>> ToHttpResponse<TSource>(this IObservable<HttpResponseMessage> source, JsonSerializerSettings settings = null) {
			settings = settings ?? defaultSettings;
			return source.Select(response => {
				if (response.IsSuccessStatusCode) {
					var jsonString = response.Content.ReadAsStringAsync().Result;
					var dataSource = JsonConvert.DeserializeObject<TSource>(jsonString, settings);
					return new HttpResponse<TSource>() {
						StatusCode = response.StatusCode,
						DataSet = dataSource
					};
				} else {
					return new HttpResponse<TSource>() {
						StatusCode = response.StatusCode,
						Reason = response.ReasonPhrase
					};
				}
			});
		}

		private static JsonSerializerSettings defaultSettings = new JsonSerializerSettings() {
			ContractResolver = new CamelCasePropertyNamesContractResolver()
		};
	}
}

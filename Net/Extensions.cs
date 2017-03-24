using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace ReactiveControls.Net {
	
	public static class Extensions {

		private static readonly int BUFFER = 8192;

		private static readonly HttpClient httpClient = new HttpClient();

		private static readonly JsonSerializerSettings defaultSettings = new JsonSerializerSettings() {
			ContractResolver = new CamelCasePropertyNamesContractResolver()
		};

		public static IObservable<HttpResponse<TSource>> ToResponse<TSource>(this IObservable<HttpResponseMessage> source, JsonSerializerSettings settings = null) {
			return source.SelectMany(r => {
				if (r.StatusCode == HttpStatusCode.OK) {
					return Observable.FromAsync(async () => {
						settings = settings ?? defaultSettings;
						StringBuilder str = new StringBuilder();
						Stream input = await r.Content.ReadAsStreamAsync();
						using(BinaryReader binaryReader = new BinaryReader(input)) {
							byte[] buffer = new byte[BUFFER];
							int read;
							while((read = binaryReader.Read(buffer, 0, BUFFER)) != 0) {
								str.Append(Encoding.UTF8.GetString(buffer, 0, read));
							}
						}
						TSource content = JsonConvert.DeserializeObject<TSource>(str.ToString(), settings);
						HttpResponse<TSource> successResponse = new HttpResponse<TSource>() {
							Code = r.StatusCode,
							Content = content
						};
						return successResponse;
					});
				} else {
					HttpResponse<TSource> errorResponse = new HttpResponse<TSource>() {
						Code = r.StatusCode,
						ReasonPhrase = r.ReasonPhrase
					};
					return Observable.Return(errorResponse);
				}
			});
		}

		public static IObservable<Stream> ToBinary(this Uri source) {
			return Observable.FromAsync(async () => {
				return await httpClient.GetStreamAsync(source);
			});
		}
	}
}

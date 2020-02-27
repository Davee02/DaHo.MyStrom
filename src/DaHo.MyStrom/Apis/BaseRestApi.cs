using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DaHo.MyStrom
{
    public abstract class BaseRestApi
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new JsonConverter[] { new StringEnumConverter() }
        };

        protected BaseRestApi(string baseAddress, HttpMessageHandler handler = null)
        {
            Client = handler == null
                ? new HttpClient()
                : new HttpClient(handler);
            Client.BaseAddress = new Uri(baseAddress);
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected async Task<T> GetAsync<T>(string uri) =>
            await ParseJsonAsync<T>(await Client.GetAsync(uri));

        protected async Task<string> GetStringAsync(string uri)
        {
            var response = await Client.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }

        protected T Get<T>(string uri) =>
            ParseJson<T>(Client.GetAsync(uri).GetAwaiter().GetResult());

        protected string GetString(string uri)
        {
            var response = Client.GetAsync(uri).GetAwaiter().GetResult();
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }


        protected async Task<T> PostAsync<T>(string uri, IDictionary<string, string> data = null) =>
            await ParseJsonAsync<T>(await Client.PostAsync(uri, new FormUrlEncodedContent(data)));

        protected async Task PostAsync(string uri, IDictionary<string, string> data = null) =>
            await Client.PostAsync(uri, new FormUrlEncodedContent(data));

        protected async Task<T> PostRawAsync<T>(string uri, StringContent data) =>
            await ParseJsonAsync<T>(await Client.PostAsync(uri, data));

        protected async Task PostRawAsync(string uri, StringContent data) =>
            await Client.PostAsync(uri, data);


        protected T Post<T>(string uri, IDictionary<string, string> data = null) =>
            ParseJson<T>(Client.PostAsync(uri, new FormUrlEncodedContent(data)).GetAwaiter().GetResult());

        protected void Post(string uri, IDictionary<string, string> data = null) =>
            Client.PostAsync(uri, new FormUrlEncodedContent(data)).GetAwaiter().GetResult();

        protected T PostRaw<T>(string uri, StringContent data) =>
            ParseJson<T>(Client.PostAsync(uri, data).GetAwaiter().GetResult());

        protected void PostRaw(string uri, StringContent data) =>
            Client.PostAsync(uri, data).GetAwaiter().GetResult();


        protected HttpClient Client { get; }



        private async Task<T> ParseJsonAsync<T>(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(responseString, _settings);
            else
                throw new InvalidOperationException($"{response.StatusCode}: {responseString}");
        }


        private T ParseJson<T>(HttpResponseMessage response)
        {
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(responseString, _settings);
            else
                throw new InvalidOperationException($"{response.StatusCode}: {responseString}");
        }
    }
}

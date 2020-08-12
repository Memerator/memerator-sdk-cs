using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Memerator.API
{
    public class API
    {
        private static readonly HttpClient client = new HttpClient();

        public API(String apiKey)
        {
            client.BaseAddress = new Uri("https://api.memerator.me/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKey);
        }

        public String get(String path) {
            return client.GetStringAsync(path).Result;
        }

        public String post(String path, Dictionary<String, String> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync(path, content).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        public String put(String path, Dictionary<String, String> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = client.PutAsync(path, content).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        public String patch(String path, Dictionary<String, String> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = client.PatchAsync(path, content).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        public String delete(String path)
        {
            return client.DeleteAsync(path).Result.Content.ReadAsStringAsync().Result;
        }
    }
}
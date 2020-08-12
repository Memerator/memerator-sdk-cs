using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Memerator.API
{
    public class API
    {
        private static readonly HttpClient Client = new HttpClient();

        public API(String apiKey)
        {
            Client.BaseAddress = new Uri("https://api.memerator.me/v1/");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKey);
        }

        public String Get(String path) {
            return Client.GetStringAsync(path).Result;
        }

        public String Post(String path, Dictionary<String, String> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = Client.PostAsync(path, content).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        public String Put(String path, Dictionary<String, String> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = Client.PutAsync(path, content).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        public String Patch(String path, Dictionary<String, String> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = Client.PatchAsync(path, content).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        public String Delete(String path)
        {
            return Client.DeleteAsync(path).Result.Content.ReadAsStringAsync().Result;
        }
    }
}
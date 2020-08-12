using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Memerator.API
{
    public class API
    {
        private static readonly HttpClient Client = new HttpClient();

        public API(string apiKey)
        {
            Client.BaseAddress = new Uri("https://api.memerator.me/v1/");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKey);
        }

        public string Get(string path) {
            return Client.GetStringAsync(path).Result;
        }

        public string Post(string path, Dictionary<string, string> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = Client.PostAsync(path, content).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        public string Put(string path, Dictionary<string, string> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = Client.PutAsync(path, content).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        public string Patch(string path, Dictionary<string, string> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = Client.PatchAsync(path, content).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        public string Delete(string path)
        {
            return Client.DeleteAsync(path).Result.Content.ReadAsStringAsync().Result;
        }
    }
}
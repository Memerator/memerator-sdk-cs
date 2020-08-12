using System;
using Memerator.API.Objects;
using Newtonsoft.Json.Linq;

namespace Memerator.API
{
    public class MemeratorAPI
    {
        private static string token;
        private static API api;

        public MemeratorAPI(string key)
        {
            token = key;
            api = new API(key);
        }
        
        public void SetToken(string newToken) 
        {
            token = newToken;
        }

        public Meme GetMeme(string id)
        {
            return new Meme(JObject.Parse(API.Get("meme/" + id)));
        }

        public User GetUser(string username)
        {
            return new User(JObject.Parse(API.Get("profile/" + username)));
        }

        public Meme RandomMeme()
        {
            return new Meme(JObject.Parse(API.Get("meme/random")));
        }
    }
}
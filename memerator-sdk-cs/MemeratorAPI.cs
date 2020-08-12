using System;
using Memerator.API.Objects;
using Newtonsoft.Json.Linq;

namespace Memerator.API
{
    public class MemeratorAPI
    {
        public static String token;
        public static API api;

        public MemeratorAPI(String key)
        {
            token = key;
            api = new API(key);
        }
        
        public void SetToken(String newToken) 
        {
            token = newToken;
        }
        
        public API GetAPI()
        {
            return api;
        }

        public Meme GetMeme(String id)
        {
            return new Meme(JObject.Parse(GetAPI().get("meme/" + id)));
        }

        public User GetUser(String username)
        {
            return new User(JObject.Parse(GetAPI().get("profile/" + username)));
        }
    }
}
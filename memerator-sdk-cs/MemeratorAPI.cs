using System;
using memerator_sdk_cs.Objects;
using Newtonsoft.Json.Linq;

namespace memerator_sdk_cs
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
            JObject response = JObject.Parse(GetAPI().get("meme/" + id));
            return new Meme(response);
        }
    }
}
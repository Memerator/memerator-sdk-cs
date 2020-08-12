using System;
using memerator_sdk_cs.Objects;

namespace memerator_sdk_cs
{
    public class MemeratorAPI
    {
        public static String token;
        public static API api;

        public MemeratorAPI(String key)
        {
            token = key;
            api = new api(newToken)
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
            JObject response = JObject.Parse(getAPI().get("meme/" + id));
            return new Meme(response);
        }
    }
}
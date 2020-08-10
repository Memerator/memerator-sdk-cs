using System;
using System.Text.Json;
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
        }
        
        public void setToken(String newToken) 
        {
            token = newToken;
            api = new API(newToken);
        }
        
        public API getAPI()
        {
            return api;
        }

        public Meme getMeme(String id)
        {
            return JsonSerializer.Deserialize<Meme>(getAPI().get("meme/" + id));
        }
    }
}
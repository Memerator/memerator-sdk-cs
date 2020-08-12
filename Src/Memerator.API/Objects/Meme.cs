using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Memerator.API.Objects
{
    public class Meme
    {
        JObject values;

        public Meme(JObject items) {
            values = items;
        }

        public string MemeId()
        {
            return values["memeid"].Value<string>();
        }

        public string Caption()
        {
            try
            {
                return values["caption"].Value<string>();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public string ImageUrl()
        {
            return values["url"].Value<string>();
        }

        public int TotalRatings()
        {
            return values["rating"]["total"].Value<int>();
        }

        public decimal AverageRating()
        {
            return values["rating"]["average"].Value<decimal>();
        }

        public DateTime Timestamp()
        {
            return values["timestamp"].Value<DateTime>();
        }
        
        public string TimeAgo()
        {
            return values["time_ago"].Value<string>();
        }

        public string MemeUrl()
        {
            return values["permalink"].Value<string>();
        }

        public bool Disabled()
        {
            return values["disabled"].Value<bool>();
        }
        
        public User Author()
        {
            return new User(values["author"].Value<JObject>());
        }
        
        public void Disable() {
            MemeratorAPI.GetAPI().Put("meme/" + MemeId() + "/disable", new Dictionary<string, string>());
            values["disabled"] = true;
        }
        
        public void Enable() {
            MemeratorAPI.GetAPI().Put("meme/" + MemeId() + "/enable", new Dictionary<string, string>());
            values["disabled"] = false;
        }

        public List<Comment> Comments()
        {
            var commentJson = JArray.Parse(MemeratorAPI.GetAPI().Get("meme/" + MemeId() + "/comments"));

            return commentJson.Select(comment => new Comment(comment.Value<JObject>())).ToList();
        }
    }
}
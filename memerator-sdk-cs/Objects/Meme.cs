using System;
using Newtonsoft.Json.Linq;

namespace memerator_sdk_cs.Objects
{
    public class Meme
    {
        JObject values;

        public Meme(JObject items) {
            values = items;
        }

        public String MemeId()
        {
            return values["memeid"].Value<String>();
        }

        public String Caption()
        {
            try
            {
                return values["caption"].Value<String>();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public String ImageUrl()
        {
            return values["url"].Value<String>();
        }

        public int TotalRatings()
        {
            return values["rating"]["total"].Value<int>();
        }

        public Decimal AverageRating()
        {
            return values["rating"]["average"].Value<Decimal>();
        }

        public DateTime Timestamp()
        {
            return values["timestamp"].Value<DateTime>();
        }
        
        public String TimeAgo()
        {
            return values["time_ago"].Value<String>();
        }

        public String MemeUrl()
        {
            return values["permalink"].Value<String>();
        }

        public Boolean Disabled()
        {
            return values["disabled"].Value<Boolean>();
        }
    }
}
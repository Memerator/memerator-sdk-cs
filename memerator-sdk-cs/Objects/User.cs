using System;
using Newtonsoft.Json.Linq;

namespace Memerator.API.Objects
{
    public class User
    {
        JObject values;

        public User(JObject items) {
            values = items;
        }

        public String Username()
        {
            return values["username"].Value<String>();
        }
        
        public long Id()
        {
            return values["id"].Value<long>();;
        }

        public String getBio()
        {
            return values["bio"].Value<String>();;
        }

        public int Followers()
        {
            return values["stats"]["followers"].Value<int>();
        }

        public int Following()
        {
            return values["stats"]["following"].Value<int>();;
        }

        public int Memes()
        {
            return values["stats"]["memes"].Value<int>();;
        }

        public Boolean Verified()
        {
            return values["perks"]["verified"].Value<Boolean>();
        }

        public Boolean Staff()
        {
            return values["perks"]["staff"].Value<Boolean>();
        }

        public Boolean Translator()
        {
            return values["perks"]["translator"].Value<Boolean>();
        }

        public Boolean Pro()
        {
            return values["perks"]["pro"].Value<Boolean>();
        }

        public Boolean Service()
        {
            return values["perks"]["service"].Value<Boolean>();
        }

        public Boolean Founder()
        {
            return values["perks"]["founder"].Value<Boolean>();
        }

        public String ProfileUrl()
        {
            return values["permalink"].Value<String>();
        }

        public DateTime JoinDate()
        {
            return DateTime.Parse(values["joined"].Value<String>());
        }
    }
}
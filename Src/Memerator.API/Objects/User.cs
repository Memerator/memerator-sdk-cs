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

        public string Username()
        {
            return values["username"].Value<string>();
        }
        
        public long Id()
        {
            return values["id"].Value<long>();;
        }

        public string getBio()
        {
            return values["bio"].Value<string>();;
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

        public bool Verified()
        {
            return values["perks"]["verified"].Value<bool>();
        }

        public bool Staff()
        {
            return values["perks"]["staff"].Value<bool>();
        }

        public bool Translator()
        {
            return values["perks"]["translator"].Value<bool>();
        }

        public bool Pro()
        {
            return values["perks"]["pro"].Value<bool>();
        }

        public bool Service()
        {
            return values["perks"]["service"].Value<bool>();
        }

        public bool Founder()
        {
            return values["perks"]["founder"].Value<bool>();
        }

        public string ProfileUrl()
        {
            return values["permalink"].Value<string>();
        }

        public DateTime JoinDate()
        {
            return DateTime.Parse(values["joined"].Value<string>());
        }
    }
}
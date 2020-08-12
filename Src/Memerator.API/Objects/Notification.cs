using System;
using System.Security.Authentication;
using Newtonsoft.Json.Linq;

namespace Memerator.API.Objects
{
    public class Notification
    {
        JObject values;

        public Notification(JObject items) {
            values = items;
        }

        public int NotificationId() {
            return values["id"].Value<int>();
        }

        public User Author() {
            return new User(values["sender"].Value<JObject>());
        }

        public DateTime Timestamp() {
            return DateTime.Parse(values["timestamp"].Value<string>());
        }

        public String MessageContent() {
            return values["message"].Value<String>();
        }

        public String RawMessageContent() {
            return values["raw"].Value<String>();
        }
        
        public int Type() {
            return values["type"].Value<int>();
        }

        public String AssociatedMemeID() {
            if (values["meme"] == null) {
                return null;
            } else {
                return values["meme"]["memeid"].Value<String>();
            }
        }

        public int AssociatedMemeRating() {
            if (values["meme"] == null) {
                return -1;
            } else {
                return values["meme"]["rating"].Value<int>();
            }
        }

        public void Delete() {
            MemeratorAPI.GetAPI().Delete("/notification/" + NotificationId());
        }
    }
}
using System;
using Newtonsoft.Json.Linq;

namespace Memerator.API.Objects
{
    public class Comment
    {
        JObject values;

        public Comment(JObject items) {
            values = items;
        }

        public int CommentId() {
            return values["id"].Value<int>();
        }

        public string CommentContent() {
            return values["content"].Value<string>();
        }

        public DateTime Timestamp() {
            return DateTime.Parse(values["timestamp"].Value<string>());
        }

        public User Author() {
            return new User(values["author"].Value<JObject>());
        }

        public Meme AssociatedMeme() {
            return new Meme(values["meme"].Value<JObject>());
        }

        public void Delete() {
            API.Delete("/notification/" + CommentId());
        }
    }
}
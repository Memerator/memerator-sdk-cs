using System;
using Newtonsoft.Json.Linq;

namespace Memerator.API.Objects
{
    public class Report
    {
        JObject values;

        public Report(JObject items) {
            values = items;
        }

        public int ReportId() {
            return values["id"].Value<int>();
        }

        public int getStatusCode() {
            return values["status"].Value<int>();
        }

        public string AssociatedMemeId() {
            return values["memeid"].Value<string>();
        }

        public string Reason() {
            return values["message"]["reason"].Value<string>();
        }

        public string getDescription() {
            return values["message"]["description"].Value<String>();
        }

        public User Assignee() {
            if(values["assignee"] == null) {
                return null;
            } else {
                return new User(values["assignee"].Value<JObject>());
            }
        }

        public String StaffComment() {
            return values["comment"].Value<String>();
        }
    }
}
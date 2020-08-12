using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Memerator.API.Objects
{
    public class Profile : User
    {
        JObject values;

        public Profile(JObject items) : base(items)
        {
            values = items;
        }
        
        public DateTime ProExpirationDate()
        {
            return DateTime.Parse(values["pro"]["expires"].Value<String>());
        }

        public DateTime ProStartDate()
        {
            return DateTime.Parse(values["pro"]["since"].Value<String>());
        }

        public Boolean ActivePro()
        {
            return values["pro"]["active"].Value<Boolean>();
        }
        
        public void SetUsername(String username)
        {
            Dictionary<String, String> body = new Dictionary<string, string>();
            body.Add("username", username);

            MemeratorAPI.GetAPI().Post("profile/me", body);
        }

        public void SetBio(string bio)
        {
            var body = new Dictionary<string, string> {{"bio", bio}};

            MemeratorAPI.GetAPI().Post("profile/me", body);
        }

        public List<Notification> Notifications()
        {
            var notificationArray = JArray.Parse(MemeratorAPI.GetAPI().Get("notifications"));

            return notificationArray.Select(notification => new Notification(notification.Value<JObject>())).ToList();
        }

        public List<Report> getReports() {
            var reportArray = JArray.Parse(MemeratorAPI.GetAPI().Get("reports"));

            return reportArray.Select(report => new Report(report.Value<JObject>())).ToList();
        }

        public Report Report(int id) {
            return new Report(JObject.Parse(MemeratorAPI.GetAPI().Get("/report/" + id)));
        }

        public int NotificationCount() {
            return JObject.Parse(MemeratorAPI.GetAPI().Get("/notifications/count"))["count"].Value<int>();
        }
    }
}
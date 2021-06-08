using System;
using System.Collections.Generic;


namespace GenericContext.Database.Models
{
    public class Notifications
    {
        public Notifications()
        {
            UserNotifications = new HashSet<UserNotifications>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationBody { get; set; }
        public string Url { get; set; }
        public int? ReferenceId { get; set; }
        public int? ReferenceTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorId { get; set; }
        public Events Event { get; set; }
        public ICollection<UserNotifications> UserNotifications { get; set; }
    }

    public class Notifications<TEvents, TUserNotifications>
    {
        public Notifications()
        {
            UserNotifications = new List<TUserNotifications>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationBody { get; set; }
        public string Url { get; set; }
        public int? ReferenceId { get; set; }
        public int? ReferenceTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorId { get; set; }
        public TEvents Event { get; set; }
        public ICollection<TUserNotifications> UserNotifications { get; set; }
    }
}

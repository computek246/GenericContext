using System;
using System.Collections.Generic;


namespace GenericContext.Database.Models
{
    public class UserNotifications
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public bool IsSeen { get; set; }
        public DateTime? SeenDate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Notifications Notification { get; set; }
    }

    public class UserNotifications<TNotifications>
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public bool IsSeen { get; set; }
        public DateTime? SeenDate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeleteDate { get; set; }
        public TNotifications Notification { get; set; }
    }
}

using System;
using System.Collections.Generic;


namespace GenericContext.Database.Models
{
    public class Events
    {
        public Events()
        {
            EventRecipient = new HashSet<EventRecipient>();
            Notifications = new HashSet<Notifications>();
        }

        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string EventName { get; set; }
        public DateTime CreationDate { get; set; }
        public Templates Template { get; set; }
        public ICollection<EventRecipient> EventRecipient { get; set; }
        public ICollection<Notifications> Notifications { get; set; }
    }

    public class Events<TTemplates, TEventRecipient, TNotifications>
    {
        public Events()
        {
            EventRecipient = new List<TEventRecipient>();
            Notifications = new List<TNotifications>();
        }

        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string EventName { get; set; }
        public DateTime CreationDate { get; set; }
        public TTemplates Template { get; set; }
        public ICollection<TEventRecipient> EventRecipient { get; set; }
        public ICollection<TNotifications> Notifications { get; set; }
    }
}

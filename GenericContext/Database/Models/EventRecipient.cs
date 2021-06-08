using System;
using System.Collections.Generic;


namespace GenericContext.Database.Models
{
    public class EventRecipient
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public Events Event { get; set; }
    }

    public class EventRecipient<TEvents>
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public TEvents Event { get; set; }
    }
}

using System;
using System.Collections.Generic;


namespace GenericContext.Database.Models
{
    public class Templates
    {
        public Templates()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public string TemplateBody { get; set; }
        public string TemplateTitle { get; set; }
        public ICollection<Events> Events { get; set; }
    }

    public class Templates<TEvents>
    {
        public Templates()
        {
            Events = new List<TEvents>();
        }

        public int Id { get; set; }
        public string TemplateBody { get; set; }
        public string TemplateTitle { get; set; }
        public ICollection<TEvents> Events { get; set; }
    }
}

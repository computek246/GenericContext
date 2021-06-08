using System;
using System.Collections.Generic;
using System.Text;

namespace GenericContext.Database.Models
{
    public class Users
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        internal string FullName => $"{this.FirstName} {this.LastName}".Trim();
    }
}

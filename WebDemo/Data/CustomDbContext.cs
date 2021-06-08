using GenericContext.Database.Data;
using GenericContext.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Data
{
    public class CustomEventRecipient : EventRecipient<CustomEvents> { public int CustomerID { get; set; } }
    public class CustomEvents : Events<CustomTemplates, CustomEventRecipient, CustomNotifications> { }
    public class CustomNotifications : Notifications<CustomEvents, CustomUserNotifications> { }
    public class CustomReferenceType : ReferenceType { }
    public class CustomTemplates : Templates<CustomEvents> { }
    public class CustomUserNotifications : UserNotifications<CustomNotifications> { }
    public class CustomUsers : IdentityUser { }

    public class Customer { }

    public class CustomDbContext : BaseDbContext<CustomUsers, CustomEventRecipient, CustomEvents, CustomNotifications, CustomReferenceType, CustomTemplates, CustomUserNotifications>
    {
        public DbSet<Customer> Customer { get; set; }

        public CustomDbContext(DbContextOptions<CustomDbContext> options)
           : base(options)
        {
        }
    }
}

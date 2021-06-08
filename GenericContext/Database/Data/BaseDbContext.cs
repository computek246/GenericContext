using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GenericContext.Database.Models;
using System.Linq;

#nullable disable

namespace GenericContext.Database.Data
{
    public class BaseDbContext : DbContext
    {

        internal protected const string schema = "notif";

        public BaseDbContext()
        {
        }

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<EventRecipient> EventRecipient { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<ReferenceType> ReferenceType { get; set; }
        public virtual DbSet<Templates> Templates { get; set; }
        public virtual DbSet<UserNotifications> UserNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");


            //exclude one table from automatic code first migrations in the Entity
            modelBuilder.Entity<Users>().ToTable(nameof(Users), t =>
            {
                t.ExcludeFromMigrations();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable(nameof(Users), "security");
                entity.HasKey(e => e.Id);
                entity.Ignore(e => e.FullName);
            });


            modelBuilder.Entity<EventRecipient>(entity =>
            {
                entity.ToTable("EventRecipient", schema);

                entity.HasIndex(e => e.EventId, "IX_EventRecipient_EventId");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventRecipient)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRecipient_Events");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.ToTable("Events", schema);

                entity.HasIndex(e => e.TemplateId, "IX_Events_TemplateId");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventName).IsRequired();

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Templates");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.ToTable("Notifications", schema);

                entity.HasIndex(e => e.CreatorId, "IX_Notifications_CreatorId");

                entity.HasIndex(e => e.EventId, "IX_Notifications_EventId");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.NotificationBody).IsRequired();

                entity.Property(e => e.NotificationTitle).IsRequired();

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_Events");
            });

            modelBuilder.Entity<ReferenceType>(entity =>
            {
                entity.ToTable("ReferenceType", schema);

                entity.Property(e => e.ReferenceTypeName).IsRequired();
            });

            modelBuilder.Entity<Templates>(entity =>
            {
                entity.ToTable("Templates", schema);

                entity.Property(e => e.TemplateBody).IsRequired();

                entity.Property(e => e.TemplateTitle).IsRequired();
            });

            modelBuilder.Entity<UserNotifications>(entity =>
            {
                entity.ToTable("UserNotifications", schema);

                entity.HasIndex(e => e.NotificationId, "IX_UserNotifications_NotificationId");

                entity.HasIndex(e => e.UserId, "IX_UserNotifications_UserId");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.SeenDate).HasColumnType("datetime");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotifications_Notifications");
            });

        }

    }

    public class BaseDbContext<TUser> : DbContext where TUser : class
    {

        internal protected const string schema = "notif";

        public BaseDbContext()
        {
        }

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<TUser> Users { get; set; }
        public virtual DbSet<EventRecipient> EventRecipient { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<ReferenceType> ReferenceType { get; set; }
        public virtual DbSet<Templates> Templates { get; set; }
        public virtual DbSet<UserNotifications> UserNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");


            //exclude one table from automatic code first migrations in the Entity
            modelBuilder.Entity<TUser>().ToTable("AspNetUsers", t =>
            {
                t.ExcludeFromMigrations();
            });


            modelBuilder.Entity<EventRecipient>(entity =>
            {
                entity.ToTable("EventRecipient", schema);

                entity.HasIndex(e => e.EventId, "IX_EventRecipient_EventId");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventRecipient)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRecipient_Events");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.ToTable("Events", schema);

                entity.HasIndex(e => e.TemplateId, "IX_Events_TemplateId");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventName).IsRequired();

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Templates");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.ToTable("Notifications", schema);

                entity.HasIndex(e => e.CreatorId, "IX_Notifications_CreatorId");

                entity.HasIndex(e => e.EventId, "IX_Notifications_EventId");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.NotificationBody).IsRequired();

                entity.Property(e => e.NotificationTitle).IsRequired();

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_Events");
            });

            modelBuilder.Entity<ReferenceType>(entity =>
            {
                entity.ToTable("ReferenceType", schema);

                entity.Property(e => e.ReferenceTypeName).IsRequired();
            });

            modelBuilder.Entity<Templates>(entity =>
            {
                entity.ToTable("Templates", schema);

                entity.Property(e => e.TemplateBody).IsRequired();

                entity.Property(e => e.TemplateTitle).IsRequired();
            });

            modelBuilder.Entity<UserNotifications>(entity =>
            {
                entity.ToTable("UserNotifications", schema);

                entity.HasIndex(e => e.NotificationId, "IX_UserNotifications_NotificationId");

                entity.HasIndex(e => e.UserId, "IX_UserNotifications_UserId");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.SeenDate).HasColumnType("datetime");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotifications_Notifications");
            });

        }

    }

    public class BaseDbContext<TUser, TEventRecipient, TEvents, TNotifications, TReferenceType, TTemplates, TUserNotifications> : DbContext
            where TUser : class
            where TEventRecipient : EventRecipient<TEvents>
            where TEvents : Events<TTemplates, TEventRecipient, TNotifications>
            where TNotifications : Notifications<TEvents, TUserNotifications>
            where TReferenceType : ReferenceType
            where TTemplates : Templates<TEvents>
            where TUserNotifications : UserNotifications<TNotifications>
    {

        internal protected const string schema = "notif";

        public BaseDbContext()
        {
        }

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<TUser> Users { get; set; }
        public virtual DbSet<TEventRecipient> EventRecipient { get; set; }
        public virtual DbSet<TEvents> Events { get; set; }
        public virtual DbSet<TNotifications> Notifications { get; set; }
        public virtual DbSet<TReferenceType> ReferenceType { get; set; }
        public virtual DbSet<TTemplates> Templates { get; set; }
        public virtual DbSet<TUserNotifications> UserNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");


            //exclude one table from automatic code first migrations in the Entity
            modelBuilder.Entity<TUser>().ToTable("AspNetUsers", t =>
            {
                t.ExcludeFromMigrations();
            });


            modelBuilder.Entity<TEventRecipient>(entity =>
            {
                entity.ToTable("EventRecipient", schema);

                entity.HasIndex(e => e.EventId, "IX_EventRecipient_EventId");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventRecipient)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRecipient_Events");
            });

            modelBuilder.Entity<TEvents>(entity =>
            {
                entity.ToTable("Events", schema);

                entity.HasIndex(e => e.TemplateId, "IX_Events_TemplateId");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventName).IsRequired();

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Templates");
            });

            modelBuilder.Entity<TNotifications>(entity =>
            {
                entity.ToTable("Notifications", schema);

                entity.HasIndex(e => e.CreatorId, "IX_Notifications_CreatorId");

                entity.HasIndex(e => e.EventId, "IX_Notifications_EventId");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.NotificationBody).IsRequired();

                entity.Property(e => e.NotificationTitle).IsRequired();

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_Events");
            });

            modelBuilder.Entity<TReferenceType>(entity =>
            {
                entity.ToTable("ReferenceType", schema);

                entity.Property(e => e.ReferenceTypeName).IsRequired();
            });

            modelBuilder.Entity<TTemplates>(entity =>
            {
                entity.ToTable("Templates", schema);

                entity.Property(e => e.TemplateBody).IsRequired();

                entity.Property(e => e.TemplateTitle).IsRequired();
            });

            modelBuilder.Entity<TUserNotifications>(entity =>
            {
                entity.ToTable("UserNotifications", schema);

                entity.HasIndex(e => e.NotificationId, "IX_UserNotifications_NotificationId");

                entity.HasIndex(e => e.UserId, "IX_UserNotifications_UserId");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.SeenDate).HasColumnType("datetime");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotifications_Notifications");
            });

        }

    }
}


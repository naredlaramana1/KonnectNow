using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using KonnectNow.Entity.Entities;

namespace KonnectNow.Repository.EF
{
     public partial class KonnectNowContext : DbContext
    {
        public KonnectNowContext()
            : base("name=KonnectNow")
        {
        }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(e => e.MessageId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Message>()
                .Property(e => e.MessageText)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.UserId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.UserId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using KonnectNow.Entity.Entities;
using KonnectNow.Entity.Mappings;

namespace KonnectNow.Repository.EF
{
     public partial class KonnectNowContext : DbContext
    {
        public KonnectNowContext()
            : base("name=KonnectNow")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Validation_Code> Validation_Code { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Entity<City>()
                .Property(e => e.City_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<City>()
                .Property(e => e.City_Name)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.State_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Locations)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

          

            modelBuilder.Entity<Location>()
                .Property(e => e.Location_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Location>()
                .Property(e => e.Location_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.City_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Message>()
                .Property(e => e.Message_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Message>()
                .Property(e => e.Query_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Message>()
                .Property(e => e.From_User_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Message>()
                .Property(e => e.To_User_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Query>()
                .Property(e => e.Query_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Query>()
                .Property(e => e.User_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Query>()
                .Property(e => e.Location_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Query>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Query)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .Property(e => e.State_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<State>()
                .Property(e => e.State_Name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.Country_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile_No)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Device_Id)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Country_Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.Map_Details)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.To_User_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.From_User_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Queries)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Validation_Code>()
                .Property(e => e.Mobile_No)
                .IsUnicode(false);
        }
    }
}

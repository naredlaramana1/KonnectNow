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
        public virtual DbSet<Validation> Validations { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Logs> Log { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new LocationMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new ValidationMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SellerMap());
            modelBuilder.Configurations.Add(new QueryMap());
            modelBuilder.Configurations.Add(new MessageMap());

            
           
        }
    }
}

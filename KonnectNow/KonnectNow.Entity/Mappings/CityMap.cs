using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            this.Property(e => e.CityId)
                   .HasPrecision(18, 0);

           this.Property(e => e.CityName)
                .IsUnicode(false);

           this.Property(e => e.StateId)
                .HasPrecision(18, 0);

            this.HasMany(e => e.Locations)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);
            this.Property(t => t.CityId).HasColumnName("City_Id");
            this.Property(t => t.CityName).HasColumnName("City_Name");
            this.Property(t => t.StateId).HasColumnName("State_Id");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.IsActive).HasColumnName("Is_Active");
            this.Property(t => t.CreatedOn).HasColumnName("Created_On");
            this.Property(t => t.ModifiedOn).HasColumnName("Modified_On");
        }
    }
}

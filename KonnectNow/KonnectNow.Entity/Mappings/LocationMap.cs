using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class LocationMap : EntityTypeConfiguration<Location>
    {
        public LocationMap()
        {
            this.Property(e => e.LocationId)
               .HasPrecision(18, 0);

           this.Property(e => e.LocationName)
                .IsUnicode(false);

          this.Property(e => e.CityId)
                .HasPrecision(18, 0);
         
          this.Property(t => t.LocationId).HasColumnName("Location_Id");
          this.Property(t => t.LocationName).HasColumnName("Location_Name");
          this.Property(t => t.CityId).HasColumnName("City_Id");
          this.Property(t => t.IsActive).HasColumnName("Is_Active");
          this.Property(t => t.CreatedOn).HasColumnName("Created_On");
          this.Property(t => t.ModifiedOn).HasColumnName("Modified_On");
          this.HasMany(e => e.Queries)
              .WithRequired(e => e.Location)
              .WillCascadeOnDelete(false);

        }

    }
}

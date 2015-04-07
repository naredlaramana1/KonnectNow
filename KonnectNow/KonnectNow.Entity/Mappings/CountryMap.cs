using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
      public CountryMap()
        {
            this.Property(e => e.CountryId)
               .HasPrecision(18, 0);

            this.Property(t => t.CountryId).HasColumnName("Country_Id");
            this.Property(t => t.CountryName).HasColumnName("Country_Name");
            this.Property(t => t.IsActive).HasColumnName("Is_Active");
            this.Property(t => t.CreatedOn).HasColumnName("Created_On");
            this.Property(t => t.ModifiedOn).HasColumnName("Modified_On");
            this.HasMany(e => e.States)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.Users)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);
            this.Property(e => e.CountryName)
                .IsUnicode(false);
            
        }
    }
}

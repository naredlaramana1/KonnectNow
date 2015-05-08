using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class QueryMap : EntityTypeConfiguration<Query>
    {
        public QueryMap()
        {
            this.Property(e => e.QueryId)
                .HasPrecision(18, 0);

           this.Property(e => e.UserId)
                .HasPrecision(18, 0);

           this.Property(e => e.CatId)
              .HasPrecision(18, 0);

           this.Property(e => e.LocationId)
                .HasPrecision(18, 0);

            this.HasMany(e => e.Messages)
                .WithRequired(e => e.Query)
                .WillCascadeOnDelete(false);

            this.Property(t => t.QueryId).HasColumnName("Query_Id");
            this.Property(t => t.UserId).HasColumnName("User_Id");
            this.Property(t => t.CatId).HasColumnName("Cat_Id");
            this.Property(t => t.QueryText).HasColumnName("Query_Text");
            this.Property(t => t.LocationId).HasColumnName("Location_Id");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.CreatedOn).HasColumnName("Created_On");
            this.Property(t => t.ModifiedOn).HasColumnName("Modified_On");
            this.Property(t => t.IsNotified).HasColumnName("IS_NOTIFIED");
        }
    }
}

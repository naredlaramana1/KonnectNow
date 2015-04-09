using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {


            this.Property(e => e.StateId)
                .HasPrecision(18, 0);

           this.Property(e => e.StateName)
                .IsUnicode(false);

           this.Property(e => e.CountryId)
                .HasPrecision(18, 0);

           this.HasMany(e => e.Cities)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);


           this.Property(t => t.StateId).HasColumnName("State_Id");
           this.Property(t => t.StateName).HasColumnName("State_Name");
           this.Property(t => t.CountryId).HasColumnName("Country_Id");
           this.Property(t => t.IsActive).HasColumnName("Is_Active");
           this.Property(t => t.CreatedOn).HasColumnName("Created_On");
           this.Property(t => t.ModifiedOn).HasColumnName("Modified_On");

        }
    }
}

using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.Property(e => e.CatId)
               .HasPrecision(18, 0);
            this.HasMany(e => e.Queries)
               .WithRequired(e => e.Category)
               .WillCascadeOnDelete(false);

            this.HasMany(e => e.Sellers)
               .WithRequired(e => e.Category)
               .WillCascadeOnDelete(false);
            this.Property(t => t.CatId).HasColumnName("Cat_Id");
            this.Property(t => t.CatName).HasColumnName("Cat_Name");
            this.Property(t => t.IsActive).HasColumnName("Is_Active");
            this.Property(t => t.CreatedOn).HasColumnName("Created_On");
            this.Property(t => t.ModifiedOn).HasColumnName("Modified_On");
            
        }
    }
}

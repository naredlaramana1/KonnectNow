using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
   public class UserMap: EntityTypeConfiguration<User>
    {
       public UserMap()
        {

            this.Property(e => e.User_Id)
                .HasPrecision(18, 0);

            this.Property(e => e.Mobile_No)
                .IsUnicode(false);

           this.Property(e => e.Device_Id)
                .IsUnicode(false);

            this.Property(e => e.Country_Id)
                .HasPrecision(18, 0);

            this.Property(e => e.Map_Details)
                .IsUnicode(false);

           this.HasMany(e => e.Messages)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.To_User_Id)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.Messages1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.From_User_Id)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.Queries)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

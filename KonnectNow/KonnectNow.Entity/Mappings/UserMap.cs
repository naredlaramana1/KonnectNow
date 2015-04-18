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

            this.Property(e => e.UserId)
                .HasPrecision(18, 0);

            this.Property(e => e.MobileNo)
                .IsUnicode(false);

           this.Property(e => e.DeviceId)
                .IsUnicode(false);

            this.Property(e => e.CountryId)
                .HasPrecision(18, 0);

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
            this.Property(t => t.UserId).HasColumnName("User_Id");
            this.Property(t => t.FirstName).HasColumnName("First_Name ");
            this.Property(t => t.LastName).HasColumnName("Last_Name");
            this.Property(t => t.MobileNo).HasColumnName("Mobile_No");
            this.Property(t => t.DeviceId).HasColumnName("Device_Id");
            this.Property(t => t.CountryId).HasColumnName("Country_Id");            
            this.Property(t => t.ProfilePic).HasColumnName("Profile_Pic");
            this.Property(t => t.CreatedOn).HasColumnName("Created_On");
            this.Property(t => t.ModifiedOn).HasColumnName("Modified_On");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.Latitude).HasColumnName("Latitude");

        }
    }
}

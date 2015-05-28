using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class SellerMap:EntityTypeConfiguration<Seller>
    {
        public SellerMap()
        {
            this.Property(e => e.CompanyId)
                .HasPrecision(18, 0);

            this.Property(e => e.UserId)
                .HasPrecision(18, 0);

            this.Property(e => e.CatId)
               .HasPrecision(18, 0);

            this.Property(e => e.PanCardNo)
                .IsUnicode(false);

            this.Property(t => t.CompanyId).HasColumnName("Company_Id");
            this.Property(t => t.CompanyName).HasColumnName("Company_Name");
            this.Property(t => t.UserId).HasColumnName("User_Id");
            this.Property(t => t.PhoneNumber).HasColumnName("Phone_Number");
            this.Property(t => t.EmailId).HasColumnName("Email_Id");
            this.Property(t => t.WebsiteUrl).HasColumnName("Website_Url");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.PanCardNo).HasColumnName("PanCard_No");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AutoReponse).HasColumnName("Auto_Reponse");
            this.Property(t => t.ResponseStatus).HasColumnName("Response_Status");
            this.Property(t => t.KeyWords).HasColumnName("Key_Words");
            this.Property(t => t.CreatedOn).HasColumnName("Created_On");
            this.Property(t => t.ModifiedOn).HasColumnName("Modified_On");
            this.Property(t => t.CatId).HasColumnName("CAT_ID");
        }

    }
}

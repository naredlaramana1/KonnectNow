using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class ValidationMap: EntityTypeConfiguration<Validation>
    {
        public ValidationMap()
        {
            this.Property(e => e.MobileNo)
                       .IsUnicode(false);

            this.Property(t => t.MobileNo).HasColumnName("Mobile_No");
            this.Property(t => t.StartDate).HasColumnName("Start_Date");
            this.Property(t => t.EndDate).HasColumnName("End_Date");
            this.Property(t => t.ValidationCode).HasColumnName("Validation_Code");
           
        }
    }
}

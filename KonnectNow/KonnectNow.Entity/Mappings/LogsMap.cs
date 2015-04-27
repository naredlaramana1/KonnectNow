using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class LogsMap : EntityTypeConfiguration<Logs>
    {
        public LogsMap()
        {
           this.Property(e => e.Level)
                    .IsUnicode(false);
        }

    }
}

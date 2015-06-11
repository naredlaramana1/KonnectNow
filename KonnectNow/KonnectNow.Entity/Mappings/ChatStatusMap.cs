using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class ChatStatusMap : EntityTypeConfiguration<ChatStatus>
    {
        public ChatStatusMap()
        {
            this.Property(e => e.ConnectId)
                    .HasPrecision(18, 0);

            this.Property(e => e.FromUserId)
                 .HasPrecision(18, 0);

            this.Property(e => e.ToUserId)
                  .HasPrecision(18, 0);
            this.Property(t => t.ConnectId).HasColumnName("Connect_Id");
            this.Property(t => t.QueryId).HasColumnName("Query_Id");
            this.Property(t => t.ToUserId).HasColumnName("To_User_Id");
            this.Property(t => t.FromUserId).HasColumnName("From_User_Id");
            this.Property(t => t.IsShared).HasColumnName("Is_Shared");
            this.Property(t => t.CreatedOn).HasColumnName("Created_On");
            
           

        }
    }
}

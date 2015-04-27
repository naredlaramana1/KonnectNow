using KonnectNow.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Mappings
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            this.Property(e => e.MessageId)
             .HasPrecision(18, 0);

           this.Property(e => e.QueryId)
                .HasPrecision(18, 0);

           this.Property(e => e.FromUserId)
                .HasPrecision(18, 0);

            this.Property(e => e.ToUserId)
                .HasPrecision(18, 0);
            this.Property(t => t.MessageId).HasColumnName("Message_Id");
            this.Property(t => t.QueryId).HasColumnName("Query_Id");
            this.Property(t => t.FromUserId).HasColumnName("From_User_Id");
            this.Property(t => t.ToUserId).HasColumnName("To_User_Id");
            this.Property(t => t.Text).HasColumnName("Message");
            this.Property(t => t.IsRead).HasColumnName("Is_Read");
            this.Property(t => t.SentOn).HasColumnName("Sent_On");
            
        }
    }
}

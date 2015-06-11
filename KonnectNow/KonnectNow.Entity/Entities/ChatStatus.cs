using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Entity.Entities
{
    [Table("Chat_Status")]
    public partial class ChatStatus
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ConnectId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal QueryId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal FromUserId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ToUserId { get; set; }

        public bool IsShared { get; set; }

         [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedOn { get; set; }
       
        public virtual Query Query { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace KonnectNow.Entity.Entities
{
   

    [Table("Message")]
    public partial class Message
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal MessageId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string MessageText { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual User User { get; set; }
    }
}

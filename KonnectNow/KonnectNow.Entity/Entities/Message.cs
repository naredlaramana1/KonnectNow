namespace KonnectNow.Entity.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal MessageId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal QueryId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal FromUserId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ToUserId { get; set; }

        [Column("Message", TypeName = "ntext")]
        [Required]
        public string Text { get; set; }

        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? SentOn { get; set; }

        public virtual Query Query { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}

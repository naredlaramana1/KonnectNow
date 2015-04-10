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
        public decimal Message_Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Query_Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal From_User_Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal To_User_Id { get; set; }

        [Column("Message", TypeName = "ntext")]
        [Required]
        public string Message1 { get; set; }

        public bool Is_Read { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Sent_On { get; set; }

        public virtual Query Query { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}

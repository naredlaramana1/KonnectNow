namespace KonnectNow.Entity.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Query")]
    public partial class Query
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Query()
        {
            Messages = new HashSet<Message>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Query_Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal User_Id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Query_Text { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Location_Id { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        public virtual User User { get; set; }
    }
}

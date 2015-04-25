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
        public decimal QueryId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UserId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CatId { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string QueryText { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LocationId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedOn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedOn { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        public virtual User User { get; set; }
       


        public virtual Category Category { get; set; }

        public virtual Location Location { get; set; }
    }
}

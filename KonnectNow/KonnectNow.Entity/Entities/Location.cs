namespace KonnectNow.Entity.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Location_Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Location_Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal City_Id { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Modified_On { get; set; }

        public virtual City City { get; set; }
    }
}

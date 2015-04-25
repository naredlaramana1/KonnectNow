namespace KonnectNow.Entity.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            Locations = new HashSet<Location>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CityId { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal StateId { get; set; }

        public bool IsActive { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedOn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedOn { get; set; }

        public virtual State State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Locations { get; set; }
    }
}

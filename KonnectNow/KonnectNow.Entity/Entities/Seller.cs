using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace KonnectNow.Entity.Entities
{
           [Table("Seller")]
        public partial class Seller
        {
            [Key]
            [Column(TypeName = "numeric")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public decimal CompanyId { get; set; }

            [Required]
            [StringLength(100)]
            public string CompanyName { get; set; }

            [Column(TypeName = "numeric")]
            public decimal UserId { get; set; }

            [Column(TypeName = "numeric")]
            public decimal CatId { get; set; }

            [Required]
            [StringLength(20)]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(250)]
            public string EmailId { get; set; }

            [StringLength(50)]
            public string WebsiteUrl { get; set; }


            public double Longitude { get; set; }

            public double Latitude { get; set; }

            

            [StringLength(15)]
            public string PanCardNo { get; set; }

            [StringLength(250)]
            public string Description { get; set; }

            [StringLength(250)]
            public string AutoReponse { get; set; }

            public bool ResponseStatus { get; set; }

            [StringLength(500)]
            public string KeyWords { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime? CreatedOn { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime? ModifiedOn { get; set; }

            public virtual User User { get; set; }
            public virtual Category Category { get; set; }
        }
 
}

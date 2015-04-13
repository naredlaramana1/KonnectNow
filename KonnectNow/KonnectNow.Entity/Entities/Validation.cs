namespace KonnectNow.Entity.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Validation_Code")]
    public partial class Validation
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MobileNo { get; set; }

        public string DeviceId { get; set; }

        [Key]
        [Column("Validation_Code", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ValidationCode { get; set; }



        [Key]
        [Column(Order = 2)]
        public DateTime StartDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime EndDate { get; set; }
    }
}

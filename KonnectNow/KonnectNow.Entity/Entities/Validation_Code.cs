namespace KonnectNow.Entity.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Validation_Code
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Mobile_No { get; set; }

        [Key]
        [Column("Validation_Code", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Validation_Code1 { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Start_Date { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime End_Date { get; set; }
    }
}

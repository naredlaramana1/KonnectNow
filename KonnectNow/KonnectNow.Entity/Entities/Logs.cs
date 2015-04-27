using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace KonnectNow.Entity.Entities
{


    public partial class Logs
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Level { get; set; }

        [Required]
        public string Message { get; set; }

        public string Exception { get; set; }
    }
}

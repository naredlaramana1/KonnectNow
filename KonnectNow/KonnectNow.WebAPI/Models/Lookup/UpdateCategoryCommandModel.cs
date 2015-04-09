using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Lookup
{
   /// <summary>
    /// UpdateCategoryCommandModel obejct
   /// </summary>
    public class UpdateCategoryCommandModel
    {

       /// <summary>
       /// Category Name
       /// </summary>
        [Required]
        [StringLength(50)]
        public string CatName { get; set; }

        

       
    }
}
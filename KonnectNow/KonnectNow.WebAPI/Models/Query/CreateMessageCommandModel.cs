using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Query
{
    /// <summary>
    /// CreateMessageCommandModel object
    /// </summary>
    public class CreateMessageCommandModel
    {
        /// <summary>
        /// From UserId
        /// </summary>
        [Required]
        public long FromUserId { get; set; }

        /// <summary>
        /// To UserId
        /// </summary>
         [Required]
        public long ToUserId { get; set; }

         /// <summary>
         /// Message
         /// </summary>
         [Required]
         public string Message { get; set; }
    }
}
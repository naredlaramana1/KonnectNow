using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Messages
{
    /// <summary>
    /// ChatCreateCommandModel object
    /// </summary>
    public class ChatCreateCommandModel
    {      

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

        /// <summary>
        /// To UserId
        /// </summary>
        [Required]
        public long QueryId { get; set; }
    }
}
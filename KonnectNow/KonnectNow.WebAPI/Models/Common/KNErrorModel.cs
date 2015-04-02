using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Common
{
    public class KNErrorModel
    {
        /// <summary>
        /// service custom code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// service custom message
        /// </summary>
        public string Message { get; set; }
    }
}
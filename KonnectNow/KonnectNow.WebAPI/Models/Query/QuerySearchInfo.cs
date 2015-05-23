using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Query
{
    /// <summary>
    /// QuerySearchInfo
    /// </summary>
    public class QuerySearchInfo
    {
        /// <summary>
        /// QueryId
        /// </summary>
        public long QueryId { get; set; }

        /// <summary>
        /// QueryText
        /// </summary>
        public string QueryText { get; set; }



        /// <summary>
        /// Created On
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
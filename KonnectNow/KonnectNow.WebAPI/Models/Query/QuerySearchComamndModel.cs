using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace KonnectNow.WebAPI.Models.Query
{
   
        /// <summary>
    /// QuerySearchComamndModel Object
    /// </summary>
    [ModelBinder(typeof(SearchQueryModelBinder))]
    public class QuerySearchComamndModel
    {

        /// <summary>
        /// Number of records to skip.If not sent, defaults to 0.
        /// </summary>
        [DefaultValue(0)]
        public int Offset { get; set; }

        /// <summary>
        /// Number of records to return.If not sent, defaults to 10.
        /// </summary>
        [DefaultValue(10)]
        public int Limit { get; set; }  
    }
}
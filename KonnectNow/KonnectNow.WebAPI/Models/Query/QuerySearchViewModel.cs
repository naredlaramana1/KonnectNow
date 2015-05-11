using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Query
{
    /// <summary>
    /// QuerySearchViewModel view Model
    /// </summary>
    public class QuerySearchViewModel:SearchViewModel
    {
          /// <summary>
        ///QuerySearchViewModel Constructor
        /// </summary>
        public QuerySearchViewModel()
        {
            SearchResults = new List<QuerySearchInfo>();
        }

         /// <summary>
        /// List of queries
        /// </summary>
        public List<QuerySearchInfo> SearchResults { get; set; }
    }
}
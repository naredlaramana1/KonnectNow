using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Messages
{

    /// <summary>
    /// LogsSearchViewModel object
    /// </summary>

    public class LogsSearchViewModel : SearchViewModel
    {

         /// <summary>
        ///LogsSearchViewModel Constructor
        /// </summary>
        public LogsSearchViewModel()
        {
            SearchResults = new List<LogsInfo>();
        }

        /// <summary>
        /// List of Messages
        /// </summary>
        public List<LogsInfo> SearchResults { get; set; }
    }
}
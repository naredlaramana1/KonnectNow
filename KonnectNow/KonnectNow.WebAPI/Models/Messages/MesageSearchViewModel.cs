using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Messages
{
    /// <summary>
    /// MesageSearchViewModel object
    /// </summary>
    public class MessageSearchViewModel : SearchViewModel
    {
        /// <summary>
        ///MesageSearchViewModel Constructor
        /// </summary>
        public MessageSearchViewModel()
        {
            SearchResults = new List<MessageSearchInfo>();
        }

        /// <summary>
        /// List of Messages
        /// </summary>
        public List<MessageSearchInfo> SearchResults { get; set; }
    }
}
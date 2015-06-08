using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Messages
{
    /// <summary>
    /// UserRespondMessageViewModel
    /// </summary>
    public class UserRespondMessageViewModel : SearchViewModel
    {
        /// <summary>
        ///UserRespondMessageViewModel Constructor
        /// </summary>
        public UserRespondMessageViewModel()
        {
            SearchResults = new List<UserRespondMessageInfo>();
        }

        /// <summary>
        /// List of Messages
        /// </summary>
        public List<UserRespondMessageInfo> SearchResults { get; set; }
    }
}
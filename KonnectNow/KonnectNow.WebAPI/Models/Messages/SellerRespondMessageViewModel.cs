using KonnectNow.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Messages
{
    /// <summary>
    /// SellerRespondMessageViewModel object
    /// </summary>
    public class SellerRespondMessageViewModel : SearchViewModel
    {
        /// <summary>
        ///SellerRespondMessageViewModel Constructor
        /// </summary>
        public SellerRespondMessageViewModel()
        {
            SearchResults = new List<SellerRespondMessageInfo>();
        }

        /// <summary>
        /// List of Messages
        /// </summary>
        public List<SellerRespondMessageInfo> SearchResults { get; set; }
    }
}
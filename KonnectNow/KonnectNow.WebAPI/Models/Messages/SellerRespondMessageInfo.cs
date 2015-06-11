using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Messages
{
    /// <summary>
    /// SellerRespondMessageInfo object
    /// </summary>
    public class SellerRespondMessageInfo
    {

        /// <summary>
        /// Seller User Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Seller Name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///Last Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Message Count
        /// </summary>
        public int MessageCount { get; set; }

        /// <summary>
        /// Is Connected
        /// </summary>
        public bool IsConnected { get; set; }

    }
}
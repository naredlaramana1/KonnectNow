using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Messages
{
    /// <summary>
    /// UserRespondMessageInfo
    /// </summary>
    public class UserRespondMessageInfo
    {

        /// <summary>
        /// Seller User Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Query Id
        /// </summary>
        public long QueryId { get; set; }

        /// <summary>
        /// Query Text
        /// </summary>
        public string QueryText { get; set; }

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
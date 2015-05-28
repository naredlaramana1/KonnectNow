using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Messages
{
    public class MessageSearchInfo
    {
        /// <summary>
        ///  Mobile No
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        ///  User Name
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        ///  User Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///  Message Id
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        ///  Message Id
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// SentOn
        /// </summary>
        public string SentOn { get; set; }

       

    }
}
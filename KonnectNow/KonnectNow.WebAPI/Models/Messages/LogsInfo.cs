using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Models.Messages
{
    public class LogsInfo
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

   
        public string Level { get; set; }

     
        public string Message { get; set; }

        public string Exception { get; set; }
    }
}
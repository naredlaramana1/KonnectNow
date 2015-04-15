using KonnectNow.WebAPI.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using KonnectNow.WebAPI.Models.Common;
namespace KonnectNow.WebAPI.Filters
{
    /// <summary>
    ///  Handles all exceptions
    /// </summary>
    public class HandleApiExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Process all Exceptions in current context
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {

             var peErrorResponse = new KNErrorModel
            {
                Code = (int)ResponseCodes.INTERNAL_SEREVR_ERROR,
                Message = EnumManager.Instance.GetDescription<ResponseCodes>(ResponseCodes.INTERNAL_SEREVR_ERROR)
            };

             context.Response = context.ActionContext.Request.CreateResponse(HttpStatusCode.InternalServerError
                                                                           , peErrorResponse
                                                                           );                                                   
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

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


            //context.Response = context.ActionContext.Request.CreateResponse(HttpStatusCode.InternalServerError
            //                                                               , ServiceResponse.Instance.BuildResponse(ResponseCodes.INTERNAL_SEREVR_ERROR)
            //                                                               );
        }
    }
}
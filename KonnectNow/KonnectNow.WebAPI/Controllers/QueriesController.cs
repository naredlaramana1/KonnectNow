using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models.Messages;
using KonnectNow.WebAPI.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

namespace KonnectNow.WebAPI.Controllers
{    /// <summary>
    /// Manages  query retaled operations
    /// </summary>
    public class QueriesController : KNBaseController
    {
        private readonly IQueryManager _queryManager;

        /// <summary>
        /// Constructor for QueriesController.
        /// </summary>
        /// <param name="queryManager">IQueryManager object</param>
        public QueriesController(IQueryManager queryManager)
        {
            _queryManager = queryManager;
        }


        /// <summary>
        /// Creates a Query
        /// </summary>
        /// <param name="createQueryCommandModel">CreateQueryCommandModel Object</param>
        /// <returns> 
        /// HTTP Status = 201 - {QueryId},
        /// HTTP Status = 404 - {Code = 4014, Message =Location not found}
        /// HTTP Status = 404 - {Code = 4003, Message =Category not found}
        /// HTTP Status = 404 - {Code = 4012, Message =User not avialable}
        /// </returns>
        [HttpPost]
        [Route("Queries")]
        [ResponseType(typeof(CreateQueryViewModel))]
        public HttpResponseMessage CreateQuery(CreateQueryCommandModel createQueryCommandModel)
        {
            var result = _queryManager.CreateQuery(createQueryCommandModel);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);
            }
            return BuildErrorResponse(result.Status);

        }


        /// <summary>
        /// returns query search list
        /// </summary>      
        /// <param name="userId">UserID</param>
        /// <param name="querySearchComamndModel">QuerySearchComamndModel</param>
        /// <returns>
        /// HTTP Status = 200 - {search results},
        /// HTTP Status = 404 - {Code = 4012, Message =User not avialable}
        /// </returns>

        [HttpGet]
        [Route("Queries/{userId}/SearchQueries")]
        [ResponseType(typeof(QuerySearchViewModel))]
        public HttpResponseMessage SearchQueries(long userId, [ModelBinder(typeof(QuerySearchModelBinder))]  QuerySearchComamndModel querySearchComamndModel)
        {
            var result = _queryManager.SearchQueries(userId, querySearchComamndModel);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);

            return BuildErrorResponse(result.Status);
        }


        /// <summary>
        /// returns message list for query
        /// </summary>
        /// <param name="queryId">QueryId</param>
        /// <returns>
        /// HTTP Status = 200 - {search results},
        /// HTTP Status = 404 - {Code = 4017, Message=Query not exist}
        /// </returns>

        [HttpGet]
        [Route("Queries/{queryId}/Messages")]
        [ResponseType(typeof(MessageSearchViewModel))]
        public HttpResponseMessage GetMessages(long queryId)
        {
            var result = _queryManager.GetMessages(queryId);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);

            return BuildErrorResponse(result.Status);
        }


        /// <summary>
        /// returns Current Logs
        /// </summary>      
        /// <returns>
       //LogsSearchViewModel
        /// </returns>

        [HttpGet]
        [Route("Logs/{limit}/{offset}")]
        [ResponseType(typeof(LogsSearchViewModel))]
        public HttpResponseMessage GetLogs([FromUri]int limit,[FromUri]int offset)
        {
            var result = _queryManager.GetLogs(limit,offset);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);

            return BuildErrorResponse(result.Status);
        }
    }
}

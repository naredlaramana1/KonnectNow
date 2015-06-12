using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models.Messages;
using KonnectNow.WebAPI.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace KonnectNow.WebAPI.Controllers
{

    /// <summary>
    /// Manages chating,notification related operations
    /// </summary>
    public class MessagesController : KNBaseController
    {
        private readonly IMessageManager _messageManager;

         /// <summary>
        /// Constructor for MessagesController.
        /// </summary>
        /// <param name="messageManager">IMessageManager object</param>
        public MessagesController(IMessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        /// <summary>
        /// Creates chating communication between two users
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="chatCreateCommandModel">ChatCreateCommandModel</param>
        /// <returns>
        /// HTTP Status = 201 - {MesageId},
        /// HTTP Status = 404 - {Code = 4017, Message=Query not exist}
        /// HTTP Status = 404 - {Code = 4012, Message =User not avialable}
        /// </returns>

        [HttpPost]
        [Route("Messages/{userId}")]
        [ResponseType(typeof(CreateMessageViewModel))]
        public HttpResponseMessage CreateChatMessage(long userId, ChatCreateCommandModel chatCreateCommandModel)
        {
            var result = _messageManager.CreateChatMessages(userId, chatCreateCommandModel);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);

            return BuildErrorResponse(result.Status);
        }


        /// <summary>
        /// returns message list for between users based on query
        /// </summary>
        /// <param name="queryId">QueryId</param>
        /// <param name="fromUserId">FromUserId</param>
        /// <param name="toUserId">ToUserId</param>
        /// <returns>
        /// HTTP Status = 200 - {search results},
        /// HTTP Status = 404 - {Code = 4017, Message=Query not exist}
        /// HTTP Status = 404 - {Code = 4012, Message=User not avialable}
        /// </returns>

        [HttpGet]
        [Route("Queries/{queryId}/ChatMessages")]
        [ResponseType(typeof(MessageSearchViewModel))]
        public HttpResponseMessage GetChatMessages(long queryId, [FromUri]long fromUserId, [FromUri] long toUserId)
        {
            var result = _messageManager.GetChatMessages(queryId, fromUserId, toUserId);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);

            return BuildErrorResponse(result.Status);
        }

        

        /// <summary>
        /// returns seller respond messages  for query
        /// </summary>
        /// <param name="queryId">QueryId</param>
        /// <param name="userId">UserId</param>
        /// <returns>
        /// HTTP Status = 200 - {search results},
        /// HTTP Status = 404 - {Code = 4017, Message=Query not exist}
        /// HTTP Status = 404 - {Code = 4012, Message=User not avialable}
        /// </returns>

        [HttpGet]
        [Route("Queries/{queryId}/SellerRespondMessages")]
        [ResponseType(typeof(SellerRespondMessageViewModel))]
        public HttpResponseMessage GetSellerRespondMessages(long queryId, [FromUri]long userId)
        {
            var result = _messageManager.GetSellerRespondMessages(queryId, userId);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);

            return BuildErrorResponse(result.Status);
        }

        /// <summary>
        /// returns user respond messages 
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns>
        /// HTTP Status = 200 - {search results},
        /// HTTP Status = 404 - {Code = 4012, Message=User not avialable}
        /// </returns>

        [HttpGet]
        [Route("UserRespondMessages/{userId}")]
        [ResponseType(typeof(UserRespondMessageViewModel))]
        public HttpResponseMessage GetUserRespondMessages(long userId)
        {
            var result = _messageManager.GetUserRespondMessages(userId);
            if (result.Status == ResponseCodes.OK)
                return BuildSuccessResponse(HttpStatusCode.OK, result.Value);

            return BuildErrorResponse(result.Status);
        }



        /// <summary>
        /// Removes a conversion between users
        /// </summary>
        /// <param name="queryId">QueryId</param> 
        /// <param name="fromUserId">FromUserId</param>
        /// <param name="toUserId">ToUserId</param>
        /// <returns>
        /// HTTP Status = 204,
        /// HTTP Status = 404 - {Code = 4017, Message=Query not exist}
        /// HTTP Status = 404 - {Code = 4012, Message=User not avialable}
        /// </returns>
        [HttpPost]
        [Route("Queries/{queryId}/Messages/{fromUserId}")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage DeleteConversion(long queryId, long fromUserId, [FromUri]long toUserId)
        {
            var result = _messageManager.DeleteConversion(queryId, fromUserId, toUserId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.NoContent);
            }
            return BuildErrorResponse(result.Status);

        }


        /// <summary>
        /// Connects two users
        /// </summary>
        /// <param name="queryId">QueryId</param> 
        /// <param name="fromUserId">FromUserId</param>
        /// <param name="toUserId">ToUserId</param>
        /// <returns>
        /// HTTP Status = 201,
        /// HTTP Status = 404 - {Code = 4017, Message=Query not exist}
        /// HTTP Status = 404 - {Code = 4012, Message=User not avialable}
        /// </returns>
        [HttpPost]
        [Route("Queries/{queryId}/ConnectUser/{fromUserId}")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage ConnectUser(long queryId, long fromUserId, [FromUri]long toUserId)
        {
            var result = _messageManager.ConnectUser(queryId, fromUserId, toUserId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.Created);
            }
            return BuildErrorResponse(result.Status);

        }

        /// <summary>
        /// Connects two users
        /// </summary>
        /// <param name="queryId">QueryId</param> 
        /// <param name="fromUserId">FromUserId</param>
        /// <param name="toUserId">ToUserId</param>
        /// <returns>
        /// HTTP Status = 201,
        /// HTTP Status = 404 - {Code = 4017, Message=Query not exist}
        /// HTTP Status = 404 - {Code = 4012, Message=User not avialable}
        /// </returns>
        [HttpPost]
        [Route("Queries/{queryId}/ShareProfile/{fromUserId}")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage ShareProfile(long queryId, long fromUserId, [FromUri]long toUserId)
        {
            var result = _messageManager.ShareProfile(queryId, fromUserId, toUserId);

            if (result.Status == ResponseCodes.OK)
            {
                return BuildSuccessResponse(HttpStatusCode.Created);
            }
            return BuildErrorResponse(result.Status);

        }
    }
}
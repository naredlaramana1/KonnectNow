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
    }
}
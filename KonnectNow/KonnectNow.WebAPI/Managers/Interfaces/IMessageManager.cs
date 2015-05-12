using KonnectNow.WebAPI.Models.Common;
using KonnectNow.WebAPI.Models.Messages;
using KonnectNow.WebAPI.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.WebAPI.Managers.Interfaces
{
    /// <summary>
    /// Manages chating,notification related operations
    /// </summary>
    public interface IMessageManager
    {
        /// <summary>
        ///Creates chating communication between two users
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="chatCreateCommandModel">ChatCreateCommandModel</param>
        /// <returns>ModelManagerResult(CreateMessageViewModel)</returns>
        ModelManagerResult<CreateMessageViewModel> CreateChatMessages(long userId, ChatCreateCommandModel chatCreateCommandModel);
    }
}

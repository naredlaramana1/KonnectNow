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

        /// <summary>
        /// Returns chat messages between two users for given query
        /// </summary>
        /// <param name="queryId">QueryId</param>   
        /// <param name="fromuserId">FromUserId</param> 
        /// <param name="toUserId">ToUserId</param> 
        /// <returns>ModelManagerResult(MessageSearchViewModel)</returns>
        ModelManagerResult<MessageSearchViewModel> GetChatMessages(long queryId, long fromuserId, long toUserId);


        /// <summary>
        /// returns responded seller message details
        /// </summary>
        /// <param name="queryId">QueryId</param>   
        /// <param name="userId">UserId</param> 
        /// <returns>ModelManagerResult(SellerRespondMessageViewModel)</returns>
        ModelManagerResult<SellerRespondMessageViewModel> GetSellerRespondMessages(long queryId, long userId);


        /// <summary>
        /// returns responded  messages to seller  details
        /// </summary>    
        /// <param name="userId">UserId</param> 
        /// <returns>ModelManagerResult(UserRespondMessageViewModel)</returns>
        ModelManagerResult<UserRespondMessageViewModel> GetUserRespondMessages(long userId);

        /// <summary>
        /// Deletes Conversion messages
        /// </summary>
        /// <param name="queryId">QueryId</param> 
        /// <param name="fromUserId">FromUserId</param>      
        ///  <param name="toUserId">ToUserId</param>    
        /// <returns>ModelManagerResult(Boolean)</returns>
        ModelManagerResult<bool> DeleteConversion(long queryId, long fromUserId, long toUserId);

        /// <summary>
        ///Connects two users
        /// </summary>
        /// <param name="queryId">QueryId</param> 
        /// <param name="fromUserId">FromUserId</param>      
        ///  <param name="toUserId">ToUserId</param>    
        /// <returns>ModelManagerResult(Boolean)</returns>
        ModelManagerResult<bool> ConnectUser(long queryId, long fromUserId, long toUserId);

         /// <summary>
        ///Shares the User profile
        /// </summary>
        /// <param name="queryId">QueryId</param> 
        /// <param name="fromUserId">FromUserId</param>      
        ///  <param name="toUserId">ToUserId</param>    
        /// <returns>ModelManagerResult(Boolean)</returns>    
        ModelManagerResult<bool> ShareProfile(long queryId, long fromUserId, long toUserId);
    }
}

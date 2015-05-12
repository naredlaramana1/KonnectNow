using AutoMapper;
using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;
using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models.Common;
using KonnectNow.WebAPI.Models.Messages;
using KonnectNow.WebAPI.Models.Query;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace KonnectNow.WebAPI.Managers
{
    /// <summary>
    /// Manages chating,notification related operations
    /// </summary>

    public class MessageManager : BaseModelManager, IMessageManager
    {
         private readonly IUserRepository _userRepository;
        private readonly IQueryRepository _queryRepository;    
        private readonly IMessageRepository _messageRepository;
     
        /// <summary>
        /// Constructor for MessageManager.
        /// </summary>
        /// <param name="userRepository">IUserRepository object</param>
        /// <param name="queryRepository">IQueryRepository object</param>         
        /// <param name="messageRepository">IMessageRepository object</param>
        public MessageManager(IUserRepository userRepository,
                            IQueryRepository queryRepository,                           
                            IMessageRepository messageRepository
                            )
        {
            _userRepository = userRepository;
            _queryRepository = queryRepository;            
            _messageRepository = messageRepository;
           
        }
        /// <summary>
        ///Creates chating communication between two users
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="chatCreateCommandModel">ChatCreateCommandModel</param>
        /// <returns>ModelManagerResult(CreateMessageViewModel)</returns>
        [UnitOfWork]
        public ModelManagerResult<CreateMessageViewModel> CreateChatMessages(long userId, ChatCreateCommandModel chatCreateCommandModel)
        {
            if (_queryRepository.GetByID(chatCreateCommandModel.QueryId) == null)
                return GetManagerResult<CreateMessageViewModel>(ResponseCodes.QUERY_NOT_EXIST);
            var user=_userRepository.GetByID(chatCreateCommandModel.ToUserId);
            if (_userRepository.GetByID(userId) == null || user == null)
                return GetManagerResult<CreateMessageViewModel>(ResponseCodes.USER_NOT_FOUND);
            SendNotification(user.DeviceId,chatCreateCommandModel.Message);
            var message = Mapper.Map<ChatCreateCommandModel, Message>(chatCreateCommandModel);        
            _messageRepository.Insert(message);
            return GetManagerResult(ResponseCodes.OK, new CreateMessageViewModel { MessageId = Convert.ToInt64(message.MessageId) });
        }


       private string SendNotification(string deviceId, string message)
    {
        string GoogleAppID = ConfigurationManager.AppSettings["GoogleAppID"].ToString();        
        var SENDER_ID = "9999999999";
        var value = message;
        WebRequest tRequest;
        tRequest = WebRequest.Create(ConfigurationManager.AppSettings["GCMURL"].ToString());
        tRequest.Method = "post";
        tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
        tRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));

        tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

        string postData = string.Format(ConfigurationManager.AppSettings["GCMMessage"].ToString(), message, System.DateTime.Now.ToString(), message);
        Console.WriteLine(postData);
        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        tRequest.ContentLength = byteArray.Length;

        Stream dataStream = tRequest.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        WebResponse tResponse = tRequest.GetResponse();

        dataStream = tResponse.GetResponseStream();

        StreamReader tReader = new StreamReader(dataStream);

        String sResponseFromServer = tReader.ReadToEnd();
        
        tReader.Close();
        dataStream.Close();
        tResponse.Close();
        return sResponseFromServer;
    }
    }
}
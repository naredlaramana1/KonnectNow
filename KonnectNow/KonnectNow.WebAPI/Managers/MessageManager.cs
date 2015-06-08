using AutoMapper;
using KonnectNow.Common.Logging;
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
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
            SendGCMNotification(user.DeviceId, chatCreateCommandModel.Message, Convert.ToString(chatCreateCommandModel.QueryId), Convert.ToString(userId));
            var message = Mapper.Map<ChatCreateCommandModel, Message>(chatCreateCommandModel);
            message.FromUserId = userId;
            _messageRepository.Insert(message);
            return GetManagerResult(ResponseCodes.OK, new CreateMessageViewModel { MessageId = Convert.ToInt64(message.MessageId) });
        }


       private int SendNotification(string deviceId, string message,string queryId,string userId)
    {
        string GoogleAppID = ConfigurationManager.AppSettings["GoogleAppID"].ToString();;
        var SENDER_ID = "9999999999";
        var value = message;
        WebRequest tRequest;
        tRequest = WebRequest.Create(ConfigurationManager.AppSettings["GCMURL"].ToString());
        tRequest.Method = "post";
        //tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
        tRequest.ContentType = "application/json";
        tRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));

        tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
        string json = "{\"alert\":\"" + message + "\",\"type\":\"chat\",\"queryid\":\"" + queryId + "\",\"fromuserid\":\"" + userId + "\"}";

        string postData = string.Format(ConfigurationManager.AppSettings["GCMMessage"].ToString(), json, System.DateTime.Now.ToString(), deviceId);
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
        HttpStatusCode status = ((HttpWebResponse)tResponse).StatusCode;
        tReader.Close();
        dataStream.Close();
        tResponse.Close();
        return (int)status;
    }


       /// <summary>
       /// Send a Google Cloud Message. Uses the GCM service and your provided api key.
       /// </summary>
       /// <param name="deviceId"></param>
       /// <param name="message"></param>
       /// <param name="queryId"></param>
       /// <param name="userId"></param>
       /// <returns>The response string from the google servers</returns>
       private string SendGCMNotification(string deviceId, string message,string queryId,string userId)
       {
           string postDataContentType = "application/json";
           string apiKey = ConfigurationManager.AppSettings["GoogleAppID"].ToString();;
           string messageJson= "{\"alert\":\"" + message + "\",\"type\":\"chat\",\"queryid\":\"" + queryId + "\",\"fromuserid\":\"" + userId + "\"}";


           string postData = "{ \"registration_ids\": [ \"" + deviceId + "\" ], " + "\"data\":" + messageJson + "}";
           //string response = SendGCMNotification(apiKey, postData);
           ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

           //
           //  MESSAGE CONTENT
           byte[] byteArray = Encoding.UTF8.GetBytes(postData);

           //
           //  CREATE REQUEST
           HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["GCMURL"].ToString());
       
           Request.Method = "POST";
           Request.KeepAlive = false;
           Request.ContentType = postDataContentType;
           Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
           Request.ContentLength = byteArray.Length;

           Stream dataStream = Request.GetRequestStream();
           dataStream.Write(byteArray, 0, byteArray.Length);
           dataStream.Close();

           //
           //  SEND MESSAGE
           try
           {
               WebResponse Response = Request.GetResponse();
               HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
               if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
               {
                   return "Unauthorized - need new token";
               }
               else if (!ResponseCode.Equals(HttpStatusCode.OK))
               {
                   return "Response from web service isn't OK";
               }

               StreamReader Reader = new StreamReader(Response.GetResponseStream());
               string responseLine = Reader.ReadToEnd();
               Reader.Close();

               return responseLine;
           }
           catch (Exception ex)
           {
               Logger.Instance.Log("PushError", ex);
           }
           return "error";
       }

        /// <summary>
        /// validate certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
       public static bool ValidateServerCertificate(
                                           object sender,
                                           X509Certificate certificate,
                                           X509Chain chain,
                                           SslPolicyErrors sslPolicyErrors)
       {
           return true;
       }


       /// <summary>
       /// returns chat messages between two users for given query
       /// </summary>
       /// <param name="queryId">QueryId</param>   
       /// <param name="fromuserId">FromUserId</param> 
       /// <param name="toUserId">ToUserId</param> 
       /// <returns>ModelManagerResult(MessageSearchViewModel)</returns>
       public ModelManagerResult<MessageSearchViewModel> GetChatMessages(long queryId,long fromuserId,long toUserId)
       {
           if (_queryRepository.GetByID(queryId) == null)
               return GetManagerResult<MessageSearchViewModel>(ResponseCodes.QUERY_NOT_EXIST);
           if (_userRepository.GetByID(fromuserId) == null || _userRepository.GetByID(toUserId)==null)
               return GetManagerResult<MessageSearchViewModel>(ResponseCodes.USER_NOT_FOUND);

           var messageSearchCollection = new MessageSearchViewModel
           {
               Offset = 0,
               Limit = 10,

           };
           var queryList = _messageRepository.Get(x => x.QueryId == queryId && x.IsDeleted == false && (x.User.UserId == fromuserId || x.User1.UserId == fromuserId) && (x.User1.UserId == toUserId || x.User.UserId == toUserId)).OrderBy(k => k.SentOn).ToList();
           messageSearchCollection.Total = queryList.Count;
           var itemList = queryList.Skip(0)
                          .Take(10).ToList();


           if (itemList != null && itemList.Count > 0)
           {

               foreach (var item in itemList)
               {
                   messageSearchCollection.SearchResults.Add(Mapper.Map<Message, MessageSearchInfo>(item));
               }
           }
           return GetManagerResult(ResponseCodes.OK, messageSearchCollection);
       }

       /// <summary>
       /// returns responded seller message details
       /// </summary>
       /// <param name="queryId">QueryId</param>   
       /// <param name="userId">UserId</param> 
       /// <returns>ModelManagerResult(SellerRespondMessageViewModel)</returns>
       public ModelManagerResult<SellerRespondMessageViewModel> GetSellerRespondMessages(long queryId, long userId)
       {
           if (_queryRepository.GetByID(queryId) == null)
               return GetManagerResult<SellerRespondMessageViewModel>(ResponseCodes.QUERY_NOT_EXIST);
           if (_userRepository.GetByID(userId) == null)
               return GetManagerResult<SellerRespondMessageViewModel>(ResponseCodes.USER_NOT_FOUND);

           var sellerRespondMessageSearchCollection = new SellerRespondMessageViewModel
           {
               Offset = 0,
               Limit = 10,

           };
           var messageList = _messageRepository.Get(x => x.QueryId == queryId && x.IsDeleted == false).OrderByDescending(x => x.MessageId).ToList();

           var distinctMessageList = messageList.Where((x=>x.FromUserId!=userId)).Select(x => x.FromUserId).Distinct().Skip(0)
                          .Take(10).ToList();

           foreach (var item in distinctMessageList)
           {
              var messages=messageList.Where(x=>((x.User.UserId == item || x.User1.UserId == item) && (x.User1.UserId == userId|| x.User.UserId == userId))).OrderByDescending(x=>x.MessageId).ToList();
                var message=messages.First();
                sellerRespondMessageSearchCollection.SearchResults.Add(new SellerRespondMessageInfo { Message = message.Text, MessageCount = messages.Count, UserId = Convert.ToInt64(message.FromUserId), UserName = message.User1.FirstName + " " + message.User1.LastName});
               
               
           }
           sellerRespondMessageSearchCollection.Total = sellerRespondMessageSearchCollection.SearchResults.Count;
           return GetManagerResult(ResponseCodes.OK, sellerRespondMessageSearchCollection);
       }


        /// <summary>
       /// returns responded  messages to seller  details
       /// </summary>    
       /// <param name="userId">UserId</param> 
       /// <returns>ModelManagerResult(UserRespondMessageViewModel)</returns>
       public ModelManagerResult<UserRespondMessageViewModel> GetUserRespondMessages(long userId)
       {
   
           if (_userRepository.GetByID(userId) == null)
               return GetManagerResult<UserRespondMessageViewModel>(ResponseCodes.USER_NOT_FOUND);

           var userRespondMessageSearchCollection = new UserRespondMessageViewModel
           {
               Offset = 0,
               Limit = 10,

           };
           var messageList = _messageRepository.Get(x => (x.User.UserId == userId) && x.IsDeleted == false).OrderByDescending(x => x.MessageId).ToList();

           var distinctMessageList = messageList.Where((x => x.FromUserId != userId)).Select(x => x.FromUserId).Distinct().Skip(0)
                          .Take(10).ToList();

           foreach (var item in distinctMessageList)
           {
              var messages=messageList.Where(x=> x.IsDeleted==false&&((x.User.UserId == item || x.User1.UserId == item) && (x.User1.UserId == userId|| x.User.UserId == userId))).OrderByDescending(x=>x.MessageId).ToList();
                var message=messages.First();
                userRespondMessageSearchCollection.SearchResults.Add(new UserRespondMessageInfo { Message = message.Text, MessageCount = messages.Count, UserId = Convert.ToInt64(message.FromUserId), UserName = message.User1.FirstName + " " + message.User1.LastName,QueryId=Convert.ToInt64(message.QueryId)});
               
               
           }
           userRespondMessageSearchCollection.Total = userRespondMessageSearchCollection.SearchResults.Count;
           return GetManagerResult(ResponseCodes.OK, userRespondMessageSearchCollection);
       }



       /// <summary>
       /// Deletes Conversion messages
       /// </summary>
       /// <param name="fromUserId">FromUserId</param>      
       ///  <param name="toUserId">ToUserId</param>    
       /// <returns>ModelManagerResult(Boolean)</returns>
       [UnitOfWork]
       public ModelManagerResult<bool> DeleteConversion(long fromUserId,long toUserId)
       {
           if (_userRepository.GetByID(fromUserId) == null || _userRepository.GetByID(toUserId)==null)
               return GetManagerResult<bool>(ResponseCodes.USER_NOT_FOUND);

           var message = _messageRepository.Get(x => ((x.User.UserId == fromUserId || x.User1.UserId == fromUserId) && (x.User1.UserId == toUserId || x.User.UserId == toUserId)));

           foreach (var item in message)
           {
               item.IsDeleted = true;
               //Delete query from queryrable
               _messageRepository.Update(item);
           }

           return GetManagerResult(ResponseCodes.OK, true);
       }

    

    }
}
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
using System.Linq;
using System.Web;

namespace KonnectNow.WebAPI.Managers
{
    /// <summary>
    /// Manages  Query operations
    /// </summary>
    public class QueryManager : BaseModelManager, IQueryManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IQueryRepository _queryRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ILogsRepository _logsRepository;
            /// <summary>
        /// Constructor for UserManager.
        /// </summary>
        /// <param name="userRepository">IUserRepository object</param>
        /// <param name="queryRepository">IQueryRepository object</param>   
        /// <param name="locationRepository">ILocationRepository object</param> 
        /// <param name="categoryRepository">ICategoryRepository object</param>
        /// /// <param name="messageRepository">IMessageRepository object</param>
       public QueryManager(IUserRepository userRepository,
                           IQueryRepository queryRepository,
                           ILocationRepository locationRepository,
                           ICategoryRepository categoryRepository,
                           IMessageRepository messageRepository,
                           ILogsRepository logsRepository
                           )
        {
            _userRepository = userRepository;
            _queryRepository = queryRepository;
            _locationRepository = locationRepository;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _logsRepository = logsRepository;
        }


        /// <summary>
        ///Creates Query
        /// </summary>    
        /// <param name="createQueryCommandModel">CreateQueryCommandModel object</param>
        /// <returns>QueryId</returns>
        [UnitOfWork]
        public ModelManagerResult<CreateQueryViewModel> CreateQuery(CreateQueryCommandModel createQueryCommandModel)
        {
            if (createQueryCommandModel.LocationId != null)
            {
               if(_locationRepository.GetByID(createQueryCommandModel.LocationId)==null)
                   return GetManagerResult<CreateQueryViewModel>(ResponseCodes.LOCATION_NOT_FOUND);
            }
            if(_categoryRepository.GetByID(createQueryCommandModel.CatId)==null)
            {
             return GetManagerResult<CreateQueryViewModel>(ResponseCodes.CATEGORY_NOT_FOUND);
            }
            if (_userRepository.GetByID(createQueryCommandModel.UserId) == null)
            {
                return GetManagerResult<CreateQueryViewModel>(ResponseCodes.USER_NOT_FOUND);
            }
            //Build query object
            var query = Mapper.Map<CreateQueryCommandModel, Query>(createQueryCommandModel);

            _queryRepository.Insert(query);
            return GetManagerResult(ResponseCodes.OK, new CreateQueryViewModel { QueryId = Convert.ToInt64(query.QueryId) });

        }

        /// <summary>
        /// returns query list
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="querySearchComamndModel">QuerySearchComamndModel</param>
        /// <returns></returns>
        public ModelManagerResult<QuerySearchViewModel> SearchQueries(long userId, QuerySearchComamndModel querySearchComamndModel)
        {

            var querySearchCollection = new QuerySearchViewModel
            {
                Offset = querySearchComamndModel.Offset,
                Limit = querySearchComamndModel.Limit,
                UserId = userId
            };
            var queryList=_queryRepository.Get(x => x.UserId == userId).OrderByDescending(k => k.ModifiedOn).ToList();
            querySearchCollection.Total = queryList.Count;
            var itemList = queryList.Skip(querySearchComamndModel.Offset)
                           .Take(querySearchComamndModel.Limit).ToList();


            if (itemList != null && itemList.Count> 0)
            {

                foreach (var item in itemList)
                {
                    querySearchCollection.SearchResults.Add(Mapper.Map<Query, QuerySearchInfo>(item));
                }
            }
            return GetManagerResult(ResponseCodes.OK, querySearchCollection);
        }

        /// <summary>
        /// returns messages list
        /// </summary>
        /// <param name="queryId">QueryId</param>       
        /// <returns>ModelManagerResult(MessageSearchViewModel)</returns>
        public ModelManagerResult<MessageSearchViewModel> GetMessages(long queryId)
        {
            if (_queryRepository.GetByID(queryId) == null)
                 return GetManagerResult<MessageSearchViewModel>(ResponseCodes.QUERY_NOT_EXIST);

            var messageSearchCollection = new MessageSearchViewModel
            {
                Offset = 0,
                Limit = 10,
                
            };
            var queryList = _messageRepository.Get(x => x.QueryId == queryId).OrderBy(k => k.SentOn).ToList();
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
        /// returns logs list
        /// </summary          
        /// <returns>ModelManagerResult(LogsSearchViewModel)</returns>
        public ModelManagerResult<LogsSearchViewModel> GetLogs(int limit,int offset)
        {

            var messageSearchCollection = new LogsSearchViewModel
            {
                Offset = offset,
                Limit = limit,

            };
            var queryList = _logsRepository.Get().OrderByDescending(k => k.Id).ToList();
            messageSearchCollection.Total = queryList.Count;
            var itemList = queryList.Skip(offset)
                           .Take(limit).ToList();


            if (itemList != null && itemList.Count > 0)
            {

                foreach (var item in itemList)
                {
                    messageSearchCollection.SearchResults.Add(Mapper.Map<Logs, LogsInfo>(item));
                }
            }
            return GetManagerResult(ResponseCodes.OK, messageSearchCollection);
        }
    }
}
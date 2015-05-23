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
    /// Provides Query related operations
    /// </summary>
    public interface IQueryManager
    {
         /// <summary>
        ///Creates Query
        /// </summary>    
        /// <param name="createQueryCommandModel">CreateQueryCommandModel object</param>
        /// <returns>QueryId</returns>     
        ModelManagerResult<CreateQueryViewModel> CreateQuery(CreateQueryCommandModel createQueryCommandModel);

        /// <summary>
        /// returns query list
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="querySearchComamndModel">QuerySearchComamndModel</param>
        /// <returns></returns>
        ModelManagerResult<QuerySearchViewModel> SearchQueries(long userId, QuerySearchComamndModel querySearchComamndModel);

            /// <summary>
        /// returns messages list
        /// </summary>
        /// <param name="queryId">QueryId</param>       
        /// <returns>ModelManagerResult(MessageSearchViewModel)</returns>
        ModelManagerResult<MessageSearchViewModel> GetMessages(long queryId);

        /// <summary>
        /// returns logs list
        /// </summary          
        /// <returns>ModelManagerResult(LogsSearchViewModel)</returns>
        ModelManagerResult<LogsSearchViewModel> GetLogs(int limit, int offset);

        /// <summary>
        /// Creates message replay to query
        /// </summary>
        /// <param name="queryId">QueryId</param>    
        /// <param name="createMessageCommandModel">CreateMessageCommandModel</param>
        /// <returns>ModelManagerResult(CreateMessageViewModel)</returns>
        ModelManagerResult<CreateMessageViewModel> CreateMessages(long queryId, CreateMessageCommandModel createMessageCommandModel);

        
        /// <summary>
        /// Deletes Query
        /// </summary>
        /// <param name="queryId">Query Id</param>              
        /// <returns>ModelManagerResult(Boolean)</returns>
        ModelManagerResult<bool> DeleteQuery(long queryId);
    }
}

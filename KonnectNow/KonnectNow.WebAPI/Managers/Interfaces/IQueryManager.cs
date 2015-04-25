using KonnectNow.WebAPI.Models.Common;
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
    }
}

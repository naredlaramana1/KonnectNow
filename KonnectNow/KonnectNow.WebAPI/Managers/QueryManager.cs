using AutoMapper;
using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;
using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models.Common;
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
            /// <summary>
        /// Constructor for UserManager.
        /// </summary>
        /// <param name="userRepository">IUserRepository object</param>
        /// <param name="queryRepository">IQueryRepository object</param>   
        /// <param name="locationRepository">ILocationRepository object</param> 
        /// <param name="categoryRepository">ICategoryRepository object</param>
       public QueryManager(IUserRepository userRepository,
                           IQueryRepository queryRepository,
                           ILocationRepository locationRepository,
                           ICategoryRepository categoryRepository
                           )
        {
            _userRepository = userRepository;
            _queryRepository = queryRepository;
            _locationRepository = locationRepository;
            _categoryRepository = categoryRepository;
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

    }
}
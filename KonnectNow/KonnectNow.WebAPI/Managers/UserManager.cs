using AutoMapper;
using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;
using KonnectNow.WebAPI.Infrastructure.Utilities;
using KonnectNow.WebAPI.Managers.Interfaces;
using KonnectNow.WebAPI.Models;
using KonnectNow.WebAPI.Models.Common;
using KonnectNow.WebAPI.Models.User;
using System.Collections.Generic;

namespace KonnectNow.WebAPI.Managers
{
    /// <summary>
    /// Manages user account related operations
    /// </summary>
    public class UserManager : BaseModelManager, IUserManager
    {
        private readonly IUserRepository _userRepository;


        /// <summary>
        /// Constructor for UserManager.
        /// </summary>
        /// <param name="patientRepo">IUserRepository object</param>

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        //public ModelManagerResult<UserListViewModel> GetUsers()
        //{
        //    var objUser = _userRepository.Get();
        //    var userListViewModel = new UserListViewModel
        //    {
        //        Users = Mapper.Map<IEnumerable<User>, IList<UserViewModel>>(objUser)
        //    };
        //    return GetManagerResult(ResponseCodes.OK, userListViewModel);


        //}
        [UnitOfWork]
        public ModelManagerResult<CreateUserViewModel> CreateUser(UserCommandModel userCommandModel)
        {
            var user = Mapper.Map<UserCommandModel, User>(userCommandModel);           
            var a = _userRepository.Insert(user);
            return GetManagerResult(ResponseCodes.OK, new CreateUserViewModel { UserId = a.UserId });


        }
    }
}
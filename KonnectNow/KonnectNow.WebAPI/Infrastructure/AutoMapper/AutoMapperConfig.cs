using KonnectNow.WebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonnectNow.Entity.Entities;

namespace KonnectNow.WebAPI.Infrastructure.AutoMapper
{
    public class AutoMapperConfig
    {
          /// <summary>
        /// initializes mapping  classes
        /// </summary>
        public static void Configure()
        {
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();
            Mapper.CreateMap<UserCommandModel, User>();
            Mapper.CreateMap<User, UserCommandModel>();
        }
    }
}
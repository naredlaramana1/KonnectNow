﻿using KonnectNow.WebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonnectNow.Entity.Entities;
using KonnectNow.WebAPI.Models.Lookup;

namespace KonnectNow.WebAPI.Infrastructure.AutoMapper
{
    /// <summary>
    /// Manages all entity mapping configurations
    /// </summary>
    public class AutoMapperConfig
    {
          /// <summary>
        /// initializes mapping  classes
        /// </summary>
        public static void Configure()
        {

            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryCommandModel, Category>();
            Mapper.CreateMap<Country, CountryViewModel>();
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();
            Mapper.CreateMap<UserCommandModel, User>();
            Mapper.CreateMap<User, UserCommandModel>();


        }
    }
}
using KonnectNow.WebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonnectNow.Entity.Entities;
using KonnectNow.WebAPI.Models.Lookup;
using KonnectNow.WebAPI.Models.User;

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

            Mapper.CreateMap<Category, CategoriesViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryCommandModel, Category>();
            Mapper.CreateMap<Country, CountriesViewModel>();
            Mapper.CreateMap<CreateCountryCommandModel, Country>();
            Mapper.CreateMap<Country, CountryViewModel>();
            Mapper.CreateMap<UserCommandModel, User>();
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<SellerProfileCommandModel, Seller>();
            Mapper.CreateMap<Seller,SellerViewModel>();
            Mapper.CreateMap<City, CitiesViewModel>();
            Mapper.CreateMap<Location, LocationsViewModel>();
            Mapper.CreateMap<Location, LocationViewModel>();
        }
    }
}
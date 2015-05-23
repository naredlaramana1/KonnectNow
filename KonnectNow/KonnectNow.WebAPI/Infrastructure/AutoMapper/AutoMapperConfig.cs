using KonnectNow.WebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KonnectNow.Entity.Entities;
using KonnectNow.WebAPI.Models.Lookup;
using KonnectNow.WebAPI.Models.User;
using KonnectNow.WebAPI.Models.Query;
using KonnectNow.WebAPI.Models.Messages;

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
            Mapper.CreateMap<Location, LocationGeographyViewModel>();
            Mapper.CreateMap<City, CityViewModel>();
            Mapper.CreateMap<City, CityGeographyViewModel>();
            Mapper.CreateMap<CreateCityCommandModel, City>();
            Mapper.CreateMap<CreateLocationCommandModel, Location>();
            Mapper.CreateMap<CreateQueryCommandModel, Query>();
            Mapper.CreateMap<decimal, long>().ConvertUsing(Convert.ToInt64);
            Mapper.CreateMap<Query, QuerySearchInfo>();
            Mapper.CreateMap<Message, MessageSearchInfo>().ForMember(dest => dest.MobileNo, src => src.MapFrom(y => y.User1.MobileNo))
                                                          .ForMember(dest => dest.UserName, src => src.MapFrom(y => y.User1.FirstName + "" + y.User1.LastName))
                                                          .ForMember(dest => dest.UserId, src => src.MapFrom(y => y.FromUserId));
            Mapper.CreateMap<Logs, LogsInfo>();
            Mapper.CreateMap<CreateMessageCommandModel, Message>().ForMember(dest => dest.Text, src => src.MapFrom(y => y.Message));
            Mapper.CreateMap<User, UserEditViewModel>();
            Mapper.CreateMap<ChatCreateCommandModel, Message>().ForMember(dest => dest.Text, src => src.MapFrom(y => y.Message));
        }
    }
}
using AnyDoubts.Domain.Model;
using AnyDoubts.Web.ViewModels;
using AutoMapper;

namespace AnyDoubts.Web
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<UserSignUp, User>();
        }
    }
}
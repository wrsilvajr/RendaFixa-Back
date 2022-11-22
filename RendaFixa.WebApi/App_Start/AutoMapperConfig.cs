using AutoMapper;
using RendaFixa.Domain;
using RendaFixa.WebApi.ViewModel;
using System;
using System.Linq;
using System.Reflection;

namespace RendaFixa.WebApi.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CDB, CDBViewModel>().ReverseMap();
        }
    }
}
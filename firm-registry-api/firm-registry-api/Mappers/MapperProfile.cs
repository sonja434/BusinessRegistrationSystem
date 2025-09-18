using AutoMapper;
using firm_registry_api.DTOs;
using firm_registry_api.Models;

namespace firm_registry_api.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<LoginDto, User>().ReverseMap();
            CreateMap<RegisterDto, User>().ReverseMap();
            //CreateMap<CompanyDto, Company>().ReverseMap();
        }
    }
}

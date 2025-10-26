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
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<CompanyRequestDto, CompanyRequest>().ReverseMap();
            CreateMap<EntrepreneurRequestDto, EntrepreneurRequest>().ReverseMap();
            CreateMap<FounderDto, Founder>().ReverseMap();
            CreateMap<JointStockCompanyRequestDto, JointStockCompanyRequest>().ReverseMap();
            CreateMap<LimitedCompanyRequestDto, LimitedCompanyRequest>().ReverseMap();
            CreateMap<LimitedPartnershipRequestDto, LimitedPartnershipRequest>().ReverseMap();
            CreateMap <PartnershipRequestDto, PartnershipRequest>().ReverseMap();
        }
    }
}

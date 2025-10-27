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
            CreateMap<CompanyRequestDto, CompanyRequest>()
                .ForMember(dest => dest.ActivityCodeId, opt => opt.MapFrom(src => src.ActivityCodeId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<EntrepreneurRequestDto, EntrepreneurRequest>().ReverseMap();
            CreateMap<FounderDto, Founder>().ReverseMap();
            CreateMap<JointStockCompanyRequestDto, JointStockCompanyRequest>().ReverseMap();
            CreateMap<LimitedCompanyRequestDto, LimitedCompanyRequest>().ReverseMap();
            CreateMap<LimitedPartnershipRequestDto, LimitedPartnershipRequest>().ReverseMap();
            CreateMap <PartnershipRequestDto, PartnershipRequest>().ReverseMap();
            CreateMap<ActivityGroup, ActivityGroupDto>();
            CreateMap<ActivityCode, ActivityCodeDto>();
            CreateMap<ActivitySector, ActivitySectorDto>();
            CreateMap<CompanyRequest, CompanyRequestResponseDto>()
                .Include<EntrepreneurRequest, EntrepreneurRequestResponseDto>()
                .Include<LimitedCompanyRequest, LimitedCompanyRequestResponseDto>()
                .Include<JointStockCompanyRequest, JointStockCompanyRequestResponseDto>()
                .Include<LimitedPartnershipRequest, LimitedPartnershipRequestResponseDto>()
                .Include<PartnershipRequest, PartnershipRequestResponseDto>();
            CreateMap<EntrepreneurRequest, EntrepreneurRequestResponseDto>();
            CreateMap<LimitedCompanyRequest, LimitedCompanyRequestResponseDto>();
            CreateMap<JointStockCompanyRequest, JointStockCompanyRequestResponseDto>();
            CreateMap<LimitedPartnershipRequest, LimitedPartnershipRequestResponseDto>();
            CreateMap<PartnershipRequest, PartnershipRequestResponseDto>();
        }
    }
}

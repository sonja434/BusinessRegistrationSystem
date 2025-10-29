using AutoMapper;
using firm_registry_api.DTOs;
using firm_registry_api.Models;
using firm_registry_api.Models.firm_registry_api.Models;

namespace firm_registry_api.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<LoginDto, User>().ReverseMap();
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();


            CreateMap<FounderDto, Owner>().ReverseMap(); 
            CreateMap<FounderDto, LimitedCompanyFounder>().ReverseMap(); 
            CreateMap<FounderDto, Shareholder>().ReverseMap(); 
            CreateMap<FounderDto, Partner>().ReverseMap();
            CreateMap<FounderDto, GeneralPartner>().ReverseMap(); 
            CreateMap<FounderDto, LimitedPartner>().ReverseMap(); 


            CreateMap<CompanyRequestDto, CompanyRequest>()
                         .Include<EntrepreneurRequestDto, EntrepreneurRequest>()
                         .Include<LimitedCompanyRequestDto, LimitedCompanyRequest>()
                         .Include<JointStockCompanyRequestDto, JointStockCompanyRequest>()
                         .Include<PartnershipRequestDto, PartnershipRequest>()
                         .Include<LimitedPartnershipRequestDto, LimitedPartnershipRequest>()
                         .ForMember(dest => dest.ActivityCodeId, opt => opt.MapFrom(src => src.ActivityCodeId))
                         .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<EntrepreneurRequestDto, EntrepreneurRequest>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner));

            CreateMap<EntrepreneurRequest, EntrepreneurRequestDto>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner));

            CreateMap<JointStockCompanyRequestDto, JointStockCompanyRequest>()
                .ForMember(dest => dest.Shareholders, opt => opt.MapFrom(src => src.Shareholders))
                .ReverseMap();

            CreateMap<LimitedCompanyRequestDto, LimitedCompanyRequest>()
                .ForMember(dest => dest.Founders, opt => opt.MapFrom(src => src.Founders))
                .ReverseMap();

            CreateMap<LimitedPartnershipRequestDto, LimitedPartnershipRequest>()
                .ForMember(dest => dest.GeneralPartners, opt => opt.MapFrom(src => src.GeneralPartners)) // List<FounderDto> -> List<GeneralPartner>
                .ForMember(dest => dest.LimitedPartners, opt => opt.MapFrom(src => src.LimitedPartners)) // List<FounderDto> -> List<LimitedPartner>
                .ReverseMap();

            CreateMap<PartnershipRequestDto, PartnershipRequest>()
                .ForMember(dest => dest.Partners, opt => opt.MapFrom(src => src.Partners))
                .ReverseMap();

            CreateMap<ActivitySector, ActivitySectorDto>();
            CreateMap<ActivityGroup, ActivityGroupDto>();
            CreateMap<ActivityCode, ActivityCodeDto>();

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
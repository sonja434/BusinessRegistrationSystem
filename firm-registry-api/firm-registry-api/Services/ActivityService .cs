using AutoMapper;
using firm_registry_api.DTOs;
using firm_registry_api.Repositories.Interfaces;
using firm_registry_api.Services.Interfaces;

namespace firm_registry_api.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityGroupRepository _groupRepository;
        private readonly IActivityCodeRepository _codeRepository;
        private readonly IActivitySectorRepository _sectorRepository;

        private readonly IMapper _mapper;

        public ActivityService(
            IActivitySectorRepository sectorRepository,
            IActivityGroupRepository groupRepository,
            IActivityCodeRepository codeRepository,
            IMapper mapper)
        {
            _sectorRepository = sectorRepository;
            _groupRepository = groupRepository;
            _codeRepository = codeRepository;
            _mapper = mapper;
        }

        public async Task<List<ActivitySectorDto>> GetAllSectorsAsync()
        {
            var sectors = await _sectorRepository.GetAllAsync();
            return _mapper.Map<List<ActivitySectorDto>>(sectors);
        }

        public async Task<List<ActivityGroupDto>> GetGroupsBySectorIdAsync(int sectorId)
        {
            var groups = await _groupRepository.GetBySectorIdAsync(sectorId);
            return _mapper.Map<List<ActivityGroupDto>>(groups);
        }

        public async Task<List<ActivityCodeDto>> GetCodesByGroupIdAsync(int groupId)
        {
            var codes = await _codeRepository.GetByGroupIdAsync(groupId);
            return _mapper.Map<List<ActivityCodeDto>>(codes);
        }

        public async Task<PagedResult<ActivityCodeDto>> GetPagedCodesAsync(PaginationQuery query)
        {
            var (items, totalItems) = await _codeRepository.GetPagedAsync(
                query.PageNumber,
                query.PageSize,
                query.SectorId,
                query.GroupId,
                query.Search
            );

            return new PagedResult<ActivityCodeDto>
            {
                Items = _mapper.Map<List<ActivityCodeDto>>(items),
                TotalCount = totalItems,
                Page = query.PageNumber,
                PageSize = query.PageSize
            };
        }


    }
}

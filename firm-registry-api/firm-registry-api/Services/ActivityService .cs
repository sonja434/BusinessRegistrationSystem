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
        private readonly IMapper _mapper;

        public ActivityService(
            IActivityGroupRepository groupRepository,
            IActivityCodeRepository codeRepository,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _codeRepository = codeRepository;
            _mapper = mapper;
        }

        public async Task<List<ActivityGroupDto>> GetAllGroupsAsync()
        {
            var groups = await _groupRepository.GetAllAsync();
            return _mapper.Map<List<ActivityGroupDto>>(groups);
        }

        public async Task<List<ActivityCodeDto>> GetCodesByGroupIdAsync(int groupId)
        {
            var codes = await _codeRepository.GetByGroupIdAsync(groupId);
            return _mapper.Map<List<ActivityCodeDto>>(codes);
        }
    }
}

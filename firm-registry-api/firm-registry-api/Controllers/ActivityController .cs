using firm_registry_api.DTOs;
using firm_registry_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet("groups")]
    public async Task<ActionResult<List<ActivityGroupDto>>> GetGroups()
    {
        var groups = await _activityService.GetAllGroupsAsync();
        return Ok(groups);
    }

    [HttpGet("codes/{groupId}")]
    public async Task<ActionResult<List<ActivityCodeDto>>> GetCodes(int groupId)
    {
        var codes = await _activityService.GetCodesByGroupIdAsync(groupId);
        return Ok(codes);
    }
}

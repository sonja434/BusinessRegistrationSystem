using firm_registry_api.DTOs;
using firm_registry_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/activities")]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet("sectors")]
    public async Task<ActionResult<List<ActivitySectorDto>>> GetSectors()
    {
        var sectors = await _activityService.GetAllSectorsAsync();
        return Ok(sectors);
    }

    [HttpGet("groups")]
    public async Task<ActionResult<List<ActivityGroupDto>>> GetGroups([FromQuery] int sectorId)
    {
        if (sectorId <= 0)
            return BadRequest("sectorId must be provided");

        var groups = await _activityService.GetGroupsBySectorIdAsync(sectorId);
        return Ok(groups);
    }

    [HttpGet("codes")]
    public async Task<ActionResult<List<ActivityCodeDto>>> GetCodes([FromQuery] int groupId)
    {
        if (groupId <= 0)
            return BadRequest("groupId must be provided");

        var codes = await _activityService.GetCodesByGroupIdAsync(groupId);
        return Ok(codes);
    }

    [HttpGet("codes/paged")]
    public async Task<ActionResult<PagedResult<ActivityCodeDto>>> GetPagedCodes(
    [FromQuery] PaginationQuery query)
    {
        var result = await _activityService.GetPagedCodesAsync(query);
        return Ok(result);
    }
}

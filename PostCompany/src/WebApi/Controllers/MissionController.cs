using Application.Mission.Create;
using Common.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Mission;
using Query.Mission.DTO;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MissionController : ControllerBase
{
    private readonly IMissionFacade _missionFacade;
    public MissionController(IMissionFacade missionFacade)
    {
        _missionFacade = missionFacade;
    }

    [HttpPost("Create")]
    [Authorize(Policy = "AdminPolicy")]
    [Authorize]
    public async Task<ActionResult<OperationResult>> Create(CreateMissionCommand command)
    {
        var result = await _missionFacade.Create(command);
        return Ok(result);
    }

    [HttpPost("{missionId}/IsDone")]
    public async Task<ActionResult<OperationResult>> IsDone(long missionId)
    {
        var result = await _missionFacade.IsDone(missionId);
        return Ok(result);
    }

    [HttpGet("Driver/{driverId}/Missions")]
    public async Task<ActionResult<List<MissionDto>>> GetDriverMissions(long driverId)
    {
        var missions = await _missionFacade.GetDriverMission(driverId);
        if (missions == null || missions.Count == 0)
            return NotFound();

        return Ok(missions);
    }

    [HttpGet("List")]
    [Authorize(Policy = "AdminPolicy")]
    [Authorize]
    public async Task<ActionResult<List<MissionDto>>> GetMissionList()
    {
        var missionList = await _missionFacade.GetMissionList();
        if (missionList == null || missionList.Count == 0)
            return NotFound();

        return Ok(missionList);
    }
}
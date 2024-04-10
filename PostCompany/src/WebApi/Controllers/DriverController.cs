using Application.Driver.Add;
using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Driver;
using Query.Driver.DTO;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    private readonly IDriverFacade _driverFacade;
    public DriverController(IDriverFacade driverFacade)
    {
        _driverFacade = driverFacade;
    }

    [HttpPost("Add")]
    [Authorize(Policy = "AdminPolicy")]
    [Authorize]
    public async Task<ActionResult<OperationResult>> Add(AddDriverCommand command)
    {
        var result = await _driverFacade.Add(command);
        return Ok(result);
    }

    [HttpPost("GiveMission")]
    [Authorize(Policy = "AdminPolicy")]
    [Authorize]
    public async Task<ActionResult<OperationResult>> GiveMission(long driverId, long missionId)
    {
        var result = await _driverFacade.GiveMission(driverId, missionId);
        return Ok(result);
    }

    [HttpGet("{driverId}/CurrentLocation")]
    public async Task<ActionResult<GeoLocation>> GetDriverCurrentLocation(long driverId)
    {
        var location = await _driverFacade.GetDriverCurrentLocation(driverId);
        if (location == null)
            return NotFound();

        return Ok(location);
    }

    [HttpGet("List")]
    [Authorize(Policy = "AdminPolicy")]
    [Authorize]
    public async Task<ActionResult<List<DriverDto>>> GetDriverList()
    {
        var driverList = await _driverFacade.GetDriverList();
        return Ok(driverList);
    }
}

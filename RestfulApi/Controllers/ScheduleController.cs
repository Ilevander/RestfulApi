using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.ScheduleCommands;
using RestfulApi.Features.CORS.Handlers.ScheduleHandler;
using RestfulApi.Features.CORS.Queries.ScheduleQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SchedulesController : ControllerBase
{
    private readonly GetScheduleByIdQueryHandler _getScheduleByIdQueryHandler;
    private readonly GetScheduleQueryHandler _getScheduleQueryHandler;
    private readonly CreateScheduleCommandHandler _createScheduleCommandHandler;
    private readonly RemoveScheduleCommandHandler _removeScheduleCommandHandler;
    private readonly UpdateScheduleCommandHandler _updateScheduleCommandHandler;

    public SchedulesController(GetScheduleByIdQueryHandler getScheduleByIdQueryHandler, GetScheduleQueryHandler getScheduleQueryHandler, CreateScheduleCommandHandler createScheduleCommandHandler, RemoveScheduleCommandHandler removeScheduleCommandHandler, UpdateScheduleCommandHandler updateScheduleCommandHandler)
    {
        _getScheduleByIdQueryHandler = getScheduleByIdQueryHandler;
        _getScheduleQueryHandler = getScheduleQueryHandler;
        _createScheduleCommandHandler = createScheduleCommandHandler;
        _removeScheduleCommandHandler = removeScheduleCommandHandler;
        _updateScheduleCommandHandler = updateScheduleCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> ScheduleList()
    {
        var values = await _getScheduleQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSchedule(int id)
    {
        var value = await _getScheduleByIdQueryHandler.Handle(new GetScheduleByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSchedule(CreateScheduleCommand command)
    {
        await _createScheduleCommandHandler.Handle(command);
        return Ok("Created Successfuly");
    }


    [HttpDelete]
    public async Task<IActionResult> RemoveSchedule(int id)
    {
        await _removeScheduleCommandHandler.Handle(new RemoveScheduleCommand(id));
        return Ok("Removed Successfruly");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateSchedule(UpdateScheduleCommand command)
    {
        await _updateScheduleCommandHandler.Handle(command);
        return Ok("Updated Successfuly");
    }
}

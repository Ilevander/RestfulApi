using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.RoleCommands;
using RestfulApi.Features.CORS.Handlers.RoleHandler;
using RestfulApi.Features.CORS.Queries.RoleQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly CreateRoleCommandHandler _createRoleCommandHandler;
    private readonly GetRoleByIdQueryHandler _getRoleByIdQueryHandler;
    private readonly GetRoleQueryHandler _getRoleQueryHandler;
    private readonly RemoveRoleCommandHandler _removeRoleCommandHandler;
    private readonly UpdateRoleCommandHandler _updateRoleCommandHandler;

    public RolesController(CreateRoleCommandHandler createRoleCommandHandler, GetRoleByIdQueryHandler getRoleByIdQueryHandler, GetRoleQueryHandler getRoleQueryHandler, RemoveRoleCommandHandler removeRoleCommandHandler, UpdateRoleCommandHandler updateRoleCommandHandler)
    {
        _createRoleCommandHandler = createRoleCommandHandler;
        _getRoleByIdQueryHandler = getRoleByIdQueryHandler;
        _getRoleQueryHandler = getRoleQueryHandler;
        _removeRoleCommandHandler = removeRoleCommandHandler;
        _updateRoleCommandHandler = updateRoleCommandHandler;
    }


    // GET: api/Appointments
    [HttpGet]
    public async Task<IActionResult> RoleList()
    {
        var values = await _getRoleQueryHandler.Handle();
        return Ok(values);
    }

    // GET: api/Appointments/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(int id)
    {
        var value = await _getRoleByIdQueryHandler.Handle(new GetRoleByIdQuery(id));
        return Ok(value);

    }

    // POST: api/Appointments
    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleCommand command)
    {
        await _createRoleCommandHandler.Handle(command);
        return Ok("Created Successfully");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveRole(int id)
    {
        await _removeRoleCommandHandler.Handle(new RemoveRoleCommand(id));
        return Ok("Removed Successfully");

    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole(UpdateRoleCommand command)
    {
        await _updateRoleCommandHandler.Handle(command);
        return Ok("Updated Successfully");

    }
}

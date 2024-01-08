using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.PermissionCommands;
using RestfulApi.Features.CORS.Handlers.PermissionHandler;
using RestfulApi.Features.CORS.Queries.PermissionQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PermissionsController : ControllerBase
{
    private readonly GetPermissionByIdQueryHandler _getPermissionByIdQueryHandler;
    private readonly GetPermissionQueryHandler _getPermissionQueryHandler;
    private readonly CreatePermissionCommandHandler _createPermissionCommandHandler;
    private readonly RemovePermissionCommandHandler _removePermissionCommandHandler;
    private readonly UpdatePermissionCommandHandler _updatePermissionCommandHandler;

    public PermissionsController(GetPermissionByIdQueryHandler getPermisisonByIdQueryHandler, GetPermissionQueryHandler getPermissionQueryHandler, CreatePermissionCommandHandler createPermissionCommandHandler, RemovePermissionCommandHandler removePermissionCommandHandler, UpdatePermissionCommandHandler updatePermissionCommandHandler)
    {
        _getPermissionByIdQueryHandler = getPermisisonByIdQueryHandler;
        _getPermissionQueryHandler = getPermissionQueryHandler;
        _createPermissionCommandHandler = createPermissionCommandHandler;
        _removePermissionCommandHandler = removePermissionCommandHandler;
        _updatePermissionCommandHandler = updatePermissionCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> PermissionList()
    {
        var values = await _getPermissionQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPermission(int id)
    {
        var value = await _getPermissionByIdQueryHandler.Handle(new GetPermissionByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePermission(CreatePermissionCommand command)
    {
        await _createPermissionCommandHandler.Handle(command);
        return Ok("Created Successfuly");
    }


    [HttpDelete]
    public async Task<IActionResult> RemovePermission(int id)
    {
        await _removePermissionCommandHandler.Handle(new RemovePermissionCommand(id));
        return Ok("Removed Successfruly");
    }


    [HttpPut]
    public async Task<IActionResult> UpdatePermission(UpdatePermissionCommand command)
    {
        await _updatePermissionCommandHandler.Handle(command);
        return Ok("Updated Successfuly");
    }
}

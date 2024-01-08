using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.UserCommands;
using RestfulApi.Features.CORS.Handlers.UserHandlers;
using RestfulApi.Features.CORS.Queries.UserQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly GetUserByIdQueryHandler _getUserByIdQueryHandler;
    private readonly GetUserQueryHandler _getUserQueryHandler;
    private readonly CreateUserCommandHandler _createUserCommandHandler;
    private readonly RemoveUserCommandHandler _removeUserCommandHandler;
    private readonly UpdateUserCommandHandler _updateUserCommandHandler;

    public UsersController(GetUserByIdQueryHandler getUserByIdQueryHandler, GetUserQueryHandler getUserQueryHandler, CreateUserCommandHandler createUserCommandHandler, RemoveUserCommandHandler removeUserCommandHandler, UpdateUserCommandHandler updateUserCommandHandler)
    {
        _getUserByIdQueryHandler = getUserByIdQueryHandler;
        _getUserQueryHandler = getUserQueryHandler;
        _createUserCommandHandler = createUserCommandHandler;
        _removeUserCommandHandler = removeUserCommandHandler;
        _updateUserCommandHandler = updateUserCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> UserList()
    {
        var values = await _getUserQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var value = await _getUserByIdQueryHandler.Handle(new GetUserByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        await _createUserCommandHandler.Handle(command);
        return Ok("Created Successfuly");
    }


    [HttpDelete]
    public async Task<IActionResult> RemoveUser(int id)
    {
        await _removeUserCommandHandler.Handle(new RemoveUserCommand(id));
        return Ok("Removed Successfruly");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
    {
        await _updateUserCommandHandler.Handle(command);
        return Ok("Updated Successfuly");
    }
}

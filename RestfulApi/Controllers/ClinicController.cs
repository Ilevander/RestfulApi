using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.ClinicCommands;
using RestfulApi.Features.CORS.Handlers.ClinicHandlers;
using RestfulApi.Features.CORS.Queries.ClinicQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ClinicsController : ControllerBase
{
    private readonly GetClinicByIdQueryHandler _getClinicByIdQueryHandler;
    private readonly GetClinicQueryHandler _getClinicQueryHandler;
    private readonly CreateClinicCommandHandler _createClinicCommandHandler;
    private readonly RemoveClinicCommandHandler _removeClinicCommandHandler;
    private readonly UpdateClinicCommandHandler _updateClinicCommandHandler;

    public ClinicsController(GetClinicByIdQueryHandler getClinicByIdQueryHandler, GetClinicQueryHandler getClinicQueryHandler, CreateClinicCommandHandler createClinicCommandHandler, RemoveClinicCommandHandler removeClinicCommandHandler, UpdateClinicCommandHandler updateClinicCommandHandler)
    {
        _getClinicByIdQueryHandler = getClinicByIdQueryHandler;
        _getClinicQueryHandler = getClinicQueryHandler;
        _createClinicCommandHandler = createClinicCommandHandler;
        _removeClinicCommandHandler = removeClinicCommandHandler;
        _updateClinicCommandHandler = updateClinicCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> ClinicList()
    {
        var values = await _getClinicQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClinic(int id)
    {
        var value = await _getClinicByIdQueryHandler.Handle(new GetClinicByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClinic(CreateClinicCommand command)
    {
        await _createClinicCommandHandler.Handle(command);
        return Ok("Created Successfuly");
    }


    [HttpDelete]
    public async Task<IActionResult> RemoveClinic(int id)
    {
        await _removeClinicCommandHandler.Handle(new RemoveClinicCommand(id));
        return Ok("Removed Successfruly");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateClinic(UpdateClinicCommand command)
    {
        await _updateClinicCommandHandler.Handle(command);
        return Ok("Updated Successfuly");
    }
}

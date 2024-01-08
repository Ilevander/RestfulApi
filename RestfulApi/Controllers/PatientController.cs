using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.PatientCommands;
using RestfulApi.Features.CORS.Handlers.PatientHandler;
using RestfulApi.Features.CORS.Queries.PatientQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly GetPatientByIdQueryHandler _getPatientByIdQueryHandler;
    private readonly GetPatientQueryHandler _getPatientQueryHandler;
    private readonly CreatePatientCommandHandler _createPatientCommandHandler;
    private readonly RemovePatientCommandHandler _removePatientCommandHandler;
    private readonly UpdatePatientCommandHandler _updatePatientCommandHandler;

    public PatientsController(GetPatientByIdQueryHandler getPatientByIdQueryHandler, GetPatientQueryHandler getPatientQueryHandler, CreatePatientCommandHandler createPatientCommandHandler, RemovePatientCommandHandler removePatientCommandHandler, UpdatePatientCommandHandler updatePatientCommandHandler)
    {
        _getPatientByIdQueryHandler = getPatientByIdQueryHandler;
        _getPatientQueryHandler = getPatientQueryHandler;
        _createPatientCommandHandler = createPatientCommandHandler;
        _removePatientCommandHandler = removePatientCommandHandler;
        _updatePatientCommandHandler = updatePatientCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> PatientList()
    {
        var values = await _getPatientQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var value = await _getPatientByIdQueryHandler.Handle(new GetPatientByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFee(CreatePatientCommand command)
    {
        await _createPatientCommandHandler.Handle(command);
        return Ok("Created Successfuly");
    }


    [HttpDelete]
    public async Task<IActionResult> RemovePatient(int id)
    {
        await _removePatientCommandHandler.Handle(new RemovePatientCommand(id));
        return Ok("Removed Successfruly");
    }


    [HttpPut]
    public async Task<IActionResult> UpdatePatient(UpdatePatientCommand command)
    {
        await _updatePatientCommandHandler.Handle(command);
        return Ok("Updated Successfuly");
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.AppointmentCommands;
using RestfulApi.Features.CORS.Handlers.AppointmentHandler;
using RestfulApi.Features.CORS.Queries.AppointmentQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly CreateAppointmentCommandHandler _createAppointmentCommandHandler;
    private readonly GetAppointmentByIdQueryHandler _getAppointmentByIdQueryHandler;
    private readonly GetAppointmentQueryHandler _getAppointmentQueryHandler;
    private readonly RemoveAppointmentCommandHandler _removeAppointmentCommandHandler;
    private readonly UpdateAppoitmentCommandHandler _updateAppoitmentCommandHandler;

    public AppointmentsController(CreateAppointmentCommandHandler createAppointmentCommandHandler, GetAppointmentByIdQueryHandler getAppointmentByIdQueryHandler, GetAppointmentQueryHandler getAppointmentQueryHandler, RemoveAppointmentCommandHandler removeAppointmentCommandHandler, UpdateAppoitmentCommandHandler updateAppoitmentCommandHandler)
    {
        _createAppointmentCommandHandler = createAppointmentCommandHandler;
        _getAppointmentByIdQueryHandler = getAppointmentByIdQueryHandler;
        _getAppointmentQueryHandler = getAppointmentQueryHandler;
        _removeAppointmentCommandHandler = removeAppointmentCommandHandler;
        _updateAppoitmentCommandHandler = updateAppoitmentCommandHandler;
    }


    // GET: api/Appointments
    [HttpGet]
    public async Task<IActionResult> AppointmentList()
    {
        var values = await _getAppointmentQueryHandler.Handle();
        return Ok(values);
    }

    // GET: api/Appointments/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(int id)
    {
        var value = await _getAppointmentByIdQueryHandler.Handle(new GetAppointmentByIdQuery(id));
        return Ok(value);

    }

    // POST: api/Appointments
    [HttpPost]
    public async Task<IActionResult> CreateAppointment(CreateAppointmentCommand command)
    {
        await _createAppointmentCommandHandler.Handle(command);
        return Ok("Created Successfully");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAppoinment(int id)
    {
        await _removeAppointmentCommandHandler.Handle(new RemoveAppointmentCommand(id));
        return Ok("Removed Successfully");

    }

    [HttpPut]
    public async Task<IActionResult> UpdateAppointment(UpdateAppointmentCommand command)
    {
        await _updateAppoitmentCommandHandler.Handle(command);
        return Ok("Updated Successfully");

    }
}

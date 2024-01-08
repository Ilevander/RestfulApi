using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.DoctorCommands;
using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Features.CORS.Handlers.DoctorHandler;
using RestfulApi.Features.CORS.Handlers.FeeHandlers;
using RestfulApi.Features.CORS.Queries.DoctorQueries;
using RestfulApi.Features.CORS.Queries.FeeQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly CreateDoctorCommandHandler _createDocotorCommandHandler;
    private readonly GetDoctorByIdQueryHandler _getDoctorByIdQueryHandler;
    private readonly GetDoctorQueryHandler _getDoctorQueryHandler;
    private readonly UpdateDoctorCommandHandler _updateDoctorCommandHandler;
    private readonly RemoveDoctorCommandHandler _removeDoctorCommandHandler;

    public DoctorsController(CreateDoctorCommandHandler createDocotorCommandHandler, GetDoctorByIdQueryHandler getDoctorByIdQueryHandler, GetDoctorQueryHandler getDoctorQueryHandler, UpdateDoctorCommandHandler updateDoctorCommandHandler, RemoveDoctorCommandHandler removeDoctorCommandHandler)
    {
        _createDocotorCommandHandler = createDocotorCommandHandler;
        _getDoctorByIdQueryHandler = getDoctorByIdQueryHandler;
        _getDoctorQueryHandler = getDoctorQueryHandler;
        _updateDoctorCommandHandler = updateDoctorCommandHandler;
        _removeDoctorCommandHandler = removeDoctorCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> DoctorList()
    {
        var values = await _getDoctorQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctor(int id)
    {
        var value = await _getDoctorByIdQueryHandler.Handle(new GetDoctorByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctor(CreateDoctorCommand command)
    {
        await _createDocotorCommandHandler.Handle(command);
        return Ok("Created Successfuly");
    }


    [HttpDelete]
    public async Task<IActionResult> RemoveDoctor(int id)
    {
        await _removeDoctorCommandHandler.Handle(new RemoveDoctorCommand(id));
        return Ok("Removed Successfruly");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateDoctor(UpdateDoctorCommand command)
    {
        await _updateDoctorCommandHandler.Handle(command);
        return Ok("Updated Successfuly");
    }
}

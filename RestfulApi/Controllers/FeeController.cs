using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Features.CORS.Handlers.FeeHandlers;
using RestfulApi.Features.CORS.Queries.FeeQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FeesController : ControllerBase
{
    private readonly GetFeeByIdQueryHandler _getFeeByIdQueryHandler;
    private readonly GetFeeQueryHandler _getFeeQueryHandler;
    private readonly CreateFeeCommandHandler _createFeeCommandHandler;
    private readonly RemoveFeeCommandHandler _removeFeeCommandHandler;
    private readonly UpdateFeeCommandHandler _updateFeeCommandHandler;

    public FeesController(GetFeeByIdQueryHandler getFeeByIdQueryHandler, GetFeeQueryHandler getFeeQueryHandler, CreateFeeCommandHandler createFeeCommandHandler, RemoveFeeCommandHandler removeFeeCommandHandler, UpdateFeeCommandHandler updateFeeCommandHandler)
    {
        _getFeeByIdQueryHandler = getFeeByIdQueryHandler;
        _getFeeQueryHandler = getFeeQueryHandler;
        _createFeeCommandHandler = createFeeCommandHandler;
        _removeFeeCommandHandler = removeFeeCommandHandler;
        _updateFeeCommandHandler = updateFeeCommandHandler;
    }


    [HttpGet]
    public async Task<IActionResult> FeeList()
    {
        var values = await _getFeeQueryHandler.Handle();
        return Ok(values);
     }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFee(int id)
    {
        var value = await _getFeeByIdQueryHandler.Handle(new GetFeeByIdQuery(id));
        return Ok(value);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFee(CreateFeeCommand command)
    {
        await _createFeeCommandHandler.Handle(command);
        return Ok("Created Successfuly");
    }

    
    [HttpDelete]
    public async Task<IActionResult> RemoveFee(int id)
    {
        await _removeFeeCommandHandler.Handle(new RemoveFeeCommand(id));
        return Ok("Removed Successfruly");
    }
    
   
    [HttpPut]
    public async Task<IActionResult> UpdateFee(UpdateFeeCommand command)
    {
        await _updateFeeCommandHandler.Handle(command);
        return Ok("Updated Successfuly");
    }
}

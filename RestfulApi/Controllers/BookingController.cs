using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Features.CORS.Commands.BookingCommands;
using RestfulApi.Features.CORS.Handlers.BookingHandlers;
using RestfulApi.Features.CORS.Handlers.FeeHandlers;
using RestfulApi.Features.CORS.Queries.BookingQueries;
using RestfulApi.Features.CORS.Queries.FeeQueries;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly CreateBookingCommandHandler _createBookingCommandHandler;
    private readonly GetBookingByIdQueryHandler _getBookingByIdQueryHandler;
    private readonly GetBookingQueryHandler _getBookingQueryHandler;
    private readonly RemoveBookingCommandHandler _removeBookingCommandHandler;
    private readonly UpdateBookingCommandHandler _updateBookingCommandHandler;

    public BookingsController(CreateBookingCommandHandler createBookingCommandHandler, GetBookingByIdQueryHandler getBookingByIdQueryHandler, GetBookingQueryHandler getBookingQueryHandler, RemoveBookingCommandHandler removeBookingCommandHandler, UpdateBookingCommandHandler updateBookingCommandHandler)
    {
        _createBookingCommandHandler = createBookingCommandHandler;
        _getBookingByIdQueryHandler = getBookingByIdQueryHandler;
        _getBookingQueryHandler = getBookingQueryHandler;
        _removeBookingCommandHandler = removeBookingCommandHandler;
        _updateBookingCommandHandler = updateBookingCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> BookingList()
    {
        var values = await _getBookingQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBooking(int id)
    {
        var value = await _getBookingByIdQueryHandler.Handle(new GetBookingByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingCommand command)
    {
        await _createBookingCommandHandler.Handle(command);
        return Ok("Created Successfuly");
    }


    [HttpDelete]
    public async Task<IActionResult> RemoveBooking(int id)
    {
        await _removeBookingCommandHandler.Handle(new RemoveBookingCommand(id));
        return Ok("Removed Successfruly");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateBooking(UpdateBookingCommand command)
    {
        await _updateBookingCommandHandler.Handle(command);
        return Ok("Updated Successfuly");
    }
}

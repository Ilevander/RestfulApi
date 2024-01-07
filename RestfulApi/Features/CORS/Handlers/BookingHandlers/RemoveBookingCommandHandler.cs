using RestfulApi.Features.CORS.Commands.BookingCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.BookingHandlers
{
    public class RemoveBookingCommandHandler
    {
        private readonly IRepository<Booking> _repository;

        public RemoveBookingCommandHandler(IRepository<Booking> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBookingCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);
        }
    }
}

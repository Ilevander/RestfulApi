using RestfulApi.Features.CORS.Commands.BookingCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.BookingHandlers
{
    public class CreateBookingCommandHandler
    {
        private readonly IRepository<Booking> _repository;

        public CreateBookingCommandHandler(IRepository<Booking> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBookingCommand command)
        {
            await _repository.CreateAsync(new Booking
            {
                BookingDate = command.BookingDate,
                PatientId = command.PatientId,
                ClinicId = command.ClinicId,
                Patient = command.Patient,
            });

        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using RestfulApi.Features.CORS.Commands.BookingCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.BookingHandlers
{
    public class UpdateBookingCommandHandler
    {
        private readonly IRepository <Booking> _repository;

        public UpdateBookingCommandHandler(IRepository<Booking> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBookingCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);

            if (values != null)
            {
                values.BookingDate = command.BookingDate;
                values.PatientId = command.PatientId;
                values.ClinicId = command.ClinicId;
                values.Patient = command.Patient;

                await _repository.UpdateAsync(values);
            }
            
        }
    }
}

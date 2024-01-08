using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Features.CORS.Commands.PatientCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.PatientHandler
{
    public class UpdatePatientCommandHandler
    {
        private readonly IRepository<Patient> _repository;

        public UpdatePatientCommandHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePatientCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);

            values.Name = command.Name;
            values.Mobile = command.Mobile;
            values.Address = command.Address;
            values.Email = command.Email;
            values.Password = command.Password;
            values.Username = command.Username;
            values.Appointments = command.Appointments;
            values.Bookings = command.Bookings;

            await _repository.UpdateAsync(values);
        }
    }
}

using RestfulApi.Interfaces;
using RestfulApi.Models;
using RestfulApi.Features.CORS.Commands.PatientCommands;

namespace RestfulApi.Features.CORS.Handlers.PatientHandler
{
    public class CreatePatientCommandHandler
    {
        private readonly IRepository<Patient> _repository;

        public CreatePatientCommandHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreatePatientCommand command)
        {
            await _repository.CreateAsync(new Patient
            {
                Name = command.Name,
                Mobile = command.Mobile,
                Address = command.Address,
                Email = command.Email,
                Password = command.Password,
                Username = command.Username,
                Appointments = command.Appointments,
                Bookings = command.Bookings,
            });

        }
    }
}

using RestfulApi.Features.CORS.Commands.BookingCommands;
using RestfulApi.Features.CORS.Commands.ClinicCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ClinicHandlers
{
    public class CreateClinicCommandHandler
    {
        private readonly IRepository<Clinic> _repository;

        public CreateClinicCommandHandler(IRepository<Clinic> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateClinicCommand command)
        {
            await _repository.CreateAsync(new Clinic
            {
                ClinicName = command.ClinicName,
                Location = command.Location,
                Doctors = command.Doctors,
            });

        }
    }
}

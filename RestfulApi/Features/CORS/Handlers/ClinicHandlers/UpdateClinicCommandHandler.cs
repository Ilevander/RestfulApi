
using RestfulApi.Features.CORS.Commands.ClinicCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ClinicHandlers
{
    public class UpdateClinicCommandHandler
    {
        private readonly IRepository<Clinic> _repository;

        public UpdateClinicCommandHandler(IRepository<Clinic> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateClinicCommand command)
        {
            var values = await _repository.GetByIdAsync(command.ClinicId);

                values.ClinicName = command.ClinicName;
                values.Location = command.Location;
                values.Doctors = command.Doctors;

                await _repository.UpdateAsync(values);            
        }
    }
}

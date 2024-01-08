using RestfulApi.Features.CORS.Commands.PatientCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.PatientHandler
{
    public class RemovePatientCommandHandler
    {
        private readonly IRepository<Patient> _repository;

        public RemovePatientCommandHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePatientCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);
        }
    }
}



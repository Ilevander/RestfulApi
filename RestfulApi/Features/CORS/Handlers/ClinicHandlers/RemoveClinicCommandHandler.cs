using RestfulApi.Features.CORS.Commands.BookingCommands;
using RestfulApi.Features.CORS.Commands.ClinicCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ClinicHandlers
{
    public class RemoveClinicCommandHandler
    {
        private readonly IRepository<Clinic> _repository;

        public RemoveClinicCommandHandler(IRepository<Clinic> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveClinicCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);
        }
    }
}

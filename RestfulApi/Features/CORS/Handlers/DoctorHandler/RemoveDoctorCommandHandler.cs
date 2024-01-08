using RestfulApi.Features.CORS.Commands.DoctorCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.DoctorHandler
{
    public class RemoveDoctorCommandHandler
    {
        private readonly IRepository<Doctor> _repository;

        public RemoveDoctorCommandHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveDoctorCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);
        }
    }
}

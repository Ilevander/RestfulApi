using RestfulApi.Features.CORS.Commands.AppointmentCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.AppointmentHandler
{
    public class RemoveAppointmentCommandHandler
    {
        private readonly IRepository<Appointment> _repository;

        public RemoveAppointmentCommandHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAppointmentCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}

using RestfulApi.Features.CORS.Commands.ScheduleCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ScheduleHandler
{
    public class RemoveScheduleCommandHandler
    {
        private readonly IRepository<Schedule> _repository;

        public RemoveScheduleCommandHandler(IRepository<Schedule> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveScheduleCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);
        }
    }
}

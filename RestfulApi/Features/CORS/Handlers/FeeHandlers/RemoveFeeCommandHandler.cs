using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.FeeHandlers
{
    public class RemoveFeeCommandHandler
    {
        private readonly IRepository<Fee> _repository;

        public RemoveFeeCommandHandler(IRepository<Fee> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFeeCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);
        }
    }
}

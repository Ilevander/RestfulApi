using RestfulApi.Features.CORS.Commands.UserCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.UserHandlers
{
    public class RemoveUserCommandHandler
    {
        private readonly IRepository<User> _repository;

        public RemoveUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveUserCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);
        }
    }
}

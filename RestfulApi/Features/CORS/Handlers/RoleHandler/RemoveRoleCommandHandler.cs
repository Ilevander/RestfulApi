using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Features.CORS.Commands.RoleCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.RoleHandler
{
    public class RemoveRoleCommandHandler
    {
        private readonly IRepository<Role> _repository;

        public RemoveRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRoleCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);
        }
    }
}

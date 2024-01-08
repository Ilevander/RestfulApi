using RestfulApi.Features.CORS.Commands.PermissionCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.PermissionHandler
{
    public class RemovePermissionCommandHandler
    {
        private readonly IRepository<Permission> _repository;

        public RemovePermissionCommandHandler(IRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePermissionCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);
        }
    }
}

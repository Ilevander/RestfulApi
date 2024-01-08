using RestfulApi.Features.CORS.Commands.PermissionCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.PermissionHandler
{
    public class CreatePermissionCommandHandler
    {
        private readonly IRepository<Permission> _repository;

        public CreatePermissionCommandHandler(IRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePermissionCommand command)
        {
            await _repository.CreateAsync(new Permission
            {
                RoleId = command.RoleId,
                Title = command.Title,
                Module = command.Module,
                Description = command.Description,
                Role = command.Role,
                
            });

        }
    }
}

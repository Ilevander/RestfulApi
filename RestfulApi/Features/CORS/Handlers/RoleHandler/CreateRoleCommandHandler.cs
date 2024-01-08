using RestfulApi.Features.CORS.Commands.RoleCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.RoleHandler
{
    public class CreateRoleCommandHandler
    {
        private readonly IRepository<Role> _repository;

        public CreateRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateRoleCommand command)
        {
            await _repository.CreateAsync(new Role
            {
                Title = command.Title,
                Description = command.Description,
                Permissions = command.Permissions,
                Users = command.Users,
                
            });

        }
    }
}

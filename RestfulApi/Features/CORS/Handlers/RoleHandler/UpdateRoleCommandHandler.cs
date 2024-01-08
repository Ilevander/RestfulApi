using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Features.CORS.Commands.RoleCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.RoleHandler
{
    public class UpdateRoleCommandHandler
    {
        private readonly IRepository<Role> _repository;

        public UpdateRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRoleCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);

            values.Title = command.Title;
            values.Description = command.Description;
            values.Permissions = command.Permissions;
            values.Users = command.Users;

            await _repository.UpdateAsync(values);
        }
    }
}

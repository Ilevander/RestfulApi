using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Features.CORS.Commands.PermissionCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.PermissionHandler
{
    public class UpdatePermissionCommandHandler
    {
        private readonly IRepository<Permission> _repository;

        public UpdatePermissionCommandHandler(IRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePermissionCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);

            values.RoleId= command.RoleId;
            values.Title = command.Title;
            values.Description = command.Description;
            values.Module = command.Module;
            values.Role = command.Role;

            await _repository.UpdateAsync(values);
        }
    }
}

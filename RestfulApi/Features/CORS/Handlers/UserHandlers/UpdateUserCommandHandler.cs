using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Features.CORS.Commands.UserCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler
    {
        private readonly IRepository<User> _repository;

        public UpdateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateUserCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);

            values.RoleId = command.RoleId;
            values.Username = command.Username;
            values.PasswordHash = command.PasswordHash;
            values.Email = command.Email;
            values.Date = command.Date;
            values.Address = command.Address;
            values.Role = command.Role;

            await _repository.UpdateAsync(values);
        }
    }
}

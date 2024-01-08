using RestfulApi.Features.CORS.Commands.UserCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.UserHandlers
{
    public class CreateUserCommandHandler
    {
        private readonly IRepository<User> _repository;

        public CreateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateUserCommand command)
        {
            await _repository.CreateAsync(new User
            {
                RoleId = command.RoleId,
                Username = command.Username,
                PasswordHash = command.PasswordHash,
                Email = command.Email,
                Date = command.Date,
                Address = command.Address,
                Role = command.Role,
            });

        }
    }
}

using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.UserCommands
{
    public class UpdateUserCommand
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public DateTime? Date { get; set; }
        public string? Address { get; set; }

        public virtual Role? Role { get; set; }
    }
}

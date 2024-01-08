using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.RoleCommands
{
    public class UpdateRoleCommand
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

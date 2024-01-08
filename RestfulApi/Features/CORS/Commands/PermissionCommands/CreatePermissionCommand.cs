using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.PermissionCommands
{
    public class CreatePermissionCommand
    {
        public int? RoleId { get; set; }
        public string? Title { get; set; }
        public string? Module { get; set; }
        public string? Description { get; set; }

        public virtual Role? Role { get; set; }
    }
}

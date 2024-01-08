using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Results.RoleResult
{
    public class GetRoleByIdQueryResult
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

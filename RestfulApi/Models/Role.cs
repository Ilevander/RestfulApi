using System;
using System.Collections.Generic;

namespace RestfulApi.Models
{
    public partial class Role
    {
        public Role()
        {
            Permissions = new HashSet<Permission>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

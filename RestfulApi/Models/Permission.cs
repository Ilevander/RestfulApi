using System;
using System.Collections.Generic;

namespace RestfulApi.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string? Title { get; set; }
        public string? Module { get; set; }
        public string? Description { get; set; }

        public virtual Role? Role { get; set; }
    }
}

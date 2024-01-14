using System;
using System.Collections.Generic;

namespace RestfulApi.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string? Username { get; set; } = string.Empty;
        public string? PasswordHash { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime? Date { get; set; }
        public string? Address { get; set; }

        public virtual Role? Role { get; set; }
    }
}

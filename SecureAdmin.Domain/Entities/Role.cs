using System;
using System.Collections.Generic;
using System.Text;

namespace SecureAdmin.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}

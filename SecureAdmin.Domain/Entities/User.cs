using System;
using System.Collections.Generic;
using System.Text;

namespace SecureAdmin.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}

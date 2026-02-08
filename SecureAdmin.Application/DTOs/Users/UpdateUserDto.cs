using System;
using System.Collections.Generic;
using System.Text;

namespace SecureAdmin.Application.DTOs.Users
{
    public class UpdateUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}

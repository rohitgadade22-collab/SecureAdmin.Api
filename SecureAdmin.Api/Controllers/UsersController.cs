using Microsoft.AspNetCore.Mvc;
using SecureAdmin.Application.DTOs.Users;
using SecureAdmin.Domain.Entities;
using SecureAdmin.Infrastructure.Data;
using System.Security.Cryptography;
using System.Text;

namespace SecureAdmin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto dto)
        {
            if (_context.Users.Any(u => u.Email == dto.Email))
                return BadRequest("User already exists");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new
            {
                user.UserId,
                user.FullName,
                user.Email
            });
        }
        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

    }
}

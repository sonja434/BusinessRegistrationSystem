using firm_registry_api.Data;
using firm_registry_api.DTOs;
using firm_registry_api.Models;
using firm_registry_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace firm_registry_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<User> RegisterAsync(RegisterDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                JMBG = dto.JMBG,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                Residence = dto.Residence,
                Username = dto.Email,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = Models.Enums.UserRole.User
            };

            if (!user.IsValidJMBG())
                throw new ArgumentException("JMBG nije validan.");

            if (!user.IsValidDateOfBirth())
                throw new ArgumentException("Datum rođenja nije validan.");

            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new ArgumentException("Korisnik sa ovom email adresom već postoji.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }


        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Neispravan username ili password");

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

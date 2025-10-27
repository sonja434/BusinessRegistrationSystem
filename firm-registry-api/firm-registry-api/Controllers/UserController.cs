using firm_registry_api.DTOs;
using firm_registry_api.Services;
using firm_registry_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace firm_registry_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("me")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDto dto)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            if (!int.TryParse(userIdClaim, out var userId))
                return Unauthorized();

            var updatedUser = await _userService.UpdateProfileAsync(userId, dto);
            if (updatedUser == null) return NotFound();

            return Ok(new
            {
                updatedUser.Id,
                updatedUser.FirstName,
                updatedUser.LastName,
                updatedUser.JMBG,
                updatedUser.DateOfBirth,
                updatedUser.Residence,
                updatedUser.Username,
                updatedUser.Email
            });
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            if (!int.TryParse(userIdClaim, out var userId))
                return Unauthorized();

            var user = await _userService.GetProfileAsync(userId);
            if (user == null) return NotFound();

            return Ok(new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.JMBG,
                user.DateOfBirth,
                user.Residence,
                user.Username,
                user.Email,
                user.Role
            });
        }

        [HttpPut("me/password")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            if (!int.TryParse(userIdClaim, out var userId))
                return Unauthorized();

            var result = await _userService.ChangePasswordAsync(userId, dto.CurrentPassword, dto.NewPassword);
            if (!result) return BadRequest(new { message = "Trenutna lozinka nije tačna." });

            return Ok(new { message = "Lozinka uspešno promenjena." });
        }
    }
}

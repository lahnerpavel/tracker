using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tracker.Api.Models;

namespace Tracker.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;


        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("user")]
        public async Task<IActionResult> RegisterUser(AuthDto authDto)
        {
            IdentityUser newUser = new IdentityUser
            {
                UserName = authDto.Email,
                Email = authDto.Email
            };

            IdentityResult result = await userManager.CreateAsync(newUser, authDto.Password);

            if (result.Succeeded)
            {
                IdentityUser user = await userManager.FindByEmailAsync(authDto.Email);
                UserDto userDto = await ConvertToUserDto(user);

                return Ok(userDto);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("auth")]
        public async Task<IActionResult> LogInUser(AuthDto authDto)
        {
            IdentityUser user = await userManager.FindByEmailAsync(authDto.Email);

            if (user is null)
                return NotFound();

            Microsoft.AspNetCore.Identity.SignInResult result =
                await signInManager.PasswordSignInAsync(user, authDto.Password, true, false);

            if (result.Succeeded)
            {
                UserDto userDto = await ConvertToUserDto(user);
                return Ok(userDto);
            }

            return BadRequest();
        }

        [HttpDelete("auth")]
        public async Task<IActionResult> LogOutUser()
        {
            await signInManager.SignOutAsync();

            return Ok(new { });
        }

        [Authorize]
        [HttpGet("auth")]
        public async Task<IActionResult> GetUserInfo()
        {
            IdentityUser user = await userManager.GetUserAsync(User);

            if (user is not null)
            {
                UserDto userDto = await ConvertToUserDto(user);
                return Ok(userDto);
            }

            return NotFound();
        }


        private async Task<UserDto> ConvertToUserDto(IdentityUser user)
        {
            bool isAdmin = await userManager.IsInRoleAsync(user, UserRoles.Admin.ToString());

            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                IsAdmin = isAdmin
            };
        }

    }
}
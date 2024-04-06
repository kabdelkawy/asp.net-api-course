using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICourse.Constants;
using WebAPICourse.Dtos.AccountDtos;
using WebAPICourse.Interfaces;
using WebAPICourse.Models;

namespace WebAPICourse.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager,ITokenService tokenService, SignInManager<AppUser> signInManager) 
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> AccountRegister([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };

            var createdUser = await _userManager.CreateAsync(appUser,registerDto.Password);

            if (createdUser.Succeeded)
            {
                
                var roleResult = await _userManager.AddToRoleAsync(appUser, IdentityRolesValues.USER);
                if (roleResult.Succeeded)
                {
                    UserTokenDto userInfo = new UserTokenDto 
                    { 
                        Token = _tokenService.CreateToken(appUser),
                        Email = appUser.Email,
                        Username = appUser.UserName,
                        Role = IdentityRolesValues.USER
                    };
                    return Ok(userInfo);
                }
                else return StatusCode(500, roleResult.Errors);
            }
            else return StatusCode(500, createdUser.Errors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> AccountLogin([FromBody] LoginDto loginDto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userManager.Users.FirstOrDefaultAsync(user=>user.NormalizedEmail == loginDto.Email.ToUpper());
            if (user == null) return Unauthorized("User Not Found!");
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);

            if(!result.Succeeded) return Unauthorized("Invalid Username or Password or Both");

            UserTokenDto userInfo = new UserTokenDto
            {
                Token = _tokenService.CreateToken(user),
                Email = user.Email,
                Username = user.UserName,
                Role = IdentityRolesValues.USER
            };
            return Ok(userInfo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}



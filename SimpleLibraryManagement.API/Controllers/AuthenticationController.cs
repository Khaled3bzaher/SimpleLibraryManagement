using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleLibraryManagement.Application.DTOs.Identity;
using SimpleLibraryManagement.Application.Helpers;
using SimpleLibraryManagement.Application.Shared.Response;

namespace SimpleLibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var userExist = await _userManager.FindByEmailAsync(userRegisterDto.Email);
            if(userExist is not null)
                return BadRequest(
                    new AuthResponse()
                    {
                        Result=false,
                        Errors=new List<string>()
                        {
                            "Email Already Exists"
                        }
                    }
                    );

            var isRoleExists = await _roleManager.RoleExistsAsync(userRegisterDto.Role);
            if(!isRoleExists)
                return BadRequest(new AuthResponse()
                {
                    Result = false,
                    Errors = new List<string>()
                        {
                            "Role Not Exists"
                        }
                });


            var newUser = new IdentityUser()
            {
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.Email,
                
            };
            var isCreated = await _userManager.CreateAsync(newUser,userRegisterDto.Password);

            if (!isCreated.Succeeded)
                return BadRequest(new AuthResponse()
                {
                    Result = false,
                    Errors = new List<string>()
                        {
                            "Server Error"
                        }
                });

            var addToRole = await _userManager.AddToRoleAsync(newUser,userRegisterDto.Role);

            var token = AuthenticationHelper.GenerateJwtToken(newUser, userRegisterDto.Role,_configuration);
            return Ok(new AuthResponse()
            {
                Result = true,
                Token = token
            });
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthResponse()
                {
                    Result = false,
                    Errors=new List<string>()
                    {
                        "Invalid Payload"
                    }
                });

            var userExist = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (userExist is null)
                return BadRequest(new AuthResponse()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Invalid Email"
                    }
                });

            var isCorrectPassword = await _userManager.CheckPasswordAsync(userExist, userLoginDto.Password);

            if (!isCorrectPassword)
                return BadRequest(new AuthResponse()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Invalid Credentials"
                    }
                });

            var role= await _userManager.GetRolesAsync(userExist);

            var jwtToken = AuthenticationHelper.GenerateJwtToken(userExist, role[0],_configuration);
            return Ok(new AuthResponse()
            {
                Result = true,
                Token = jwtToken
            });
        }

        [Authorize]
        [HttpGet("CheckClaims")]
        public IActionResult CheckClaims()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Ok(claims);
        }

    }
}

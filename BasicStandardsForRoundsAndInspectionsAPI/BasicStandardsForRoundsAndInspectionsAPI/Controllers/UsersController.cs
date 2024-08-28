using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.AuthenticationDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("static-login")]
        public ActionResult<TokenDTO> StaticLogin(LoginDTO loginDTO)
        {
            bool isAuthenticated = loginDTO.UserName == Constants.AppSettings.RoleAdmin
                && loginDTO.Password == Constants.AppSettings.AdminPassword;
            if (!isAuthenticated)
            {
                return Unauthorized();
            }
            //Generate Token
            var userClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new(ClaimTypes.Name, loginDTO.UserName),
                new(ClaimTypes.Role, Constants.AppSettings.RoleAdmin )
            };
            return GenerateToken(userClaims);

        }

        private ActionResult<TokenDTO> GenerateToken(IEnumerable<Claim> userClaims)
        {
            var keyFormConfig = _configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
            var keyInBytes = Encoding.ASCII.GetBytes(keyFormConfig);
            var key = new SymmetricSecurityKey(keyInBytes);

            var signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            var expiryDateTime = DateTime.Now.AddMinutes(100);

            var jwt = new JwtSecurityToken(
                claims: userClaims,
                expires: expiryDateTime,
                signingCredentials: signingCredentials);

            var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new TokenDTO(jwtAsString, expiryDateTime);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user == null)
            {
                return Unauthorized();
            }
            bool isAuthenticated = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }
            // Token
            var userClaims = await _userManager.GetClaimsAsync(user);
            return GenerateToken(userClaims);
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {
            var user = new ApplicationUser
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email

            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new(ClaimTypes.Name,user.UserName),
                new(ClaimTypes.Email,user.Email)
            };
            await _userManager.AddClaimsAsync(user, claims);
            return NoContent();
        }
    }
}

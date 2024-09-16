using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.AuthenticationDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net.Mail;
using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;

namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public UsersController(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            _configuration = configuration;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        private ActionResult<TokenDTO> GenerateToken(IEnumerable<Claim> userClaims, string role)
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
            return new TokenDTO(jwtAsString, expiryDateTime, role);
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
            var roleClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            string role = roleClaim?.Value ?? "User";

            return GenerateToken(userClaims, role);
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
                new(ClaimTypes.Email,user.Email),
                new(ClaimTypes.Role, "Admin")
            };
            await _userManager.AddClaimsAsync(user, claims);
            return NoContent();
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "Users", new { token, email = model.Email }, Request.Scheme);

            await _emailSender.SendEmailAsync(model.Email!, "Reset Password", $"Reset your password using this link: {resetLink!}");

            return Ok("Reset password email sent");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.NewPassword);
            if (result.Succeeded)
            {
                return Ok("Password has been reset successfully");
            }

            return BadRequest(result.Errors);
        }

        //    [HttpPost]
        //    [Route("reset-password")]
        //    public async Task<ActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        //    {
        //        // Step 1: Check if the username exists
        //        var user = await _userManager.FindByNameAsync(resetPasswordDTO.UserName);
        //        if (user == null)
        //        {
        //            return BadRequest("User not found.");
        //        }

        //        // Step 3: Ensure that the new password and confirm password match
        //        if (resetPasswordDTO.NewPassword != resetPasswordDTO.ConfirmPassword)
        //        {
        //            return BadRequest("New password and confirm password do not match.");
        //        }

        //        // Step 4: Update the password
        //        var result = await _userManager.ResetPasswordAsync(user,resetPasswordDTO.Token,resetPasswordDTO.NewPassword);
        //        if (!result.Succeeded)
        //        {
        //            return BadRequest(result.Errors);
        //        }

        //        return Ok("Password has been reset successfully.");
        //    }


        //    [HttpPost("forgot-password")]
        //    public async Task<IActionResult> ForgotPassword([FromBody] ForgetPasswordDTO model)
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest("Invalid Request");

        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user == null)
        //            return BadRequest("Email not found");

        //        var token = await _userManager.GeneratePasswordResetTokenAsync(user);


        //        var resetLink = $"{Request.Scheme}://{Request.Host}/api/Users/reset-password?token={token}&email={model.Email}";

        //        //var resetLink = Url.Action("reset-password", "Users", new { token, email = model.Email }, Request.Scheme);
        //        //Console.WriteLine($"Request.Scheme: {Request.Scheme}");

        //        if (string.IsNullOrEmpty(resetLink))
        //        {
        //            return BadRequest("Failed to generate reset link.");
        //        }
        //        // Send Email
        //        await _emailSender.SendEmailAsync(model.Email,
        //            "Reset Password", $"Please reset your password by clicking here: {resetLink}");
        //        if (string.IsNullOrEmpty(resetLink))
        //        {
        //            return BadRequest("Error generating reset link.");
        //        }
        //        return Ok("Password reset link has been sent to your email.");
        //    }
    }
}

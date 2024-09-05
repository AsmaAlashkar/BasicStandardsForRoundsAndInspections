using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.AuthenticationDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
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
        //[HttpPost]
        //[Route("static-login")]
        //public ActionResult<TokenDTO> StaticLogin(LoginDTO loginDTO)
        //{
        //    bool isAuthenticated = loginDTO.UserName == Constants.AppSettings.RoleAdmin
        //        && loginDTO.Password == Constants.AppSettings.AdminPassword;
        //    if (!isAuthenticated)
        //    {
        //        return Unauthorized();
        //    }
        //    //Generate Token
        //    var userClaims = new List<Claim>
        //    {
        //        new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
        //        new(ClaimTypes.Name, loginDTO.UserName),
        //        new(ClaimTypes.Role, Constants.AppSettings.RoleAdmin )
        //    };
        //    return GenerateToken(userClaims);

        //}

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


        //[HttpPost("forget-password")]
        //public async Task<ActionResult> ForgetPassword(ForgetPasswordDTO forgetPasswordDTO)
        //{
        //    // Step 1: Find the user by email
        //    var user = await _userManager.FindByEmailAsync(forgetPasswordDTO.Email);
        //    if (user == null)
        //    {
        //        return BadRequest("Email not found.");
        //    }

        //    // Step 2: Generate a password reset token
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //    // Step 3: Create a password reset link
        //    var resetLink = Url.Action("ResetPassword", "Users", new { token, email = user.Email }, Request.Scheme);

        //    // Step 4: Send the password reset link to the user's email
        //    // You should replace the below lines with your actual email sending code
        //    // using a proper mail service or SMTP server.

        //    var emailMessage = new MailMessage();
        //    emailMessage.To.Add(user.Email);
        //    emailMessage.Subject = "Password Reset";
        //    emailMessage.Body = $"Click the link to reset your password: {resetLink}";
        //    emailMessage.IsBodyHtml = true;

        //    using (var client = new SmtpClient("your.smtp.server"))
        //    {
        //        await client.SendMailAsync(emailMessage);
        //    }

        //    return Ok("Password reset link has been sent to your email.");
        //}

        [HttpPost]
        [Route("reset-password")]
        public async Task<ActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            // Step 1: Check if the username exists
            var user = await _userManager.FindByNameAsync(resetPasswordDTO.UserName);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            // Step 2: Verify that the old password matches the stored password
            bool isOldPasswordCorrect = await _userManager.CheckPasswordAsync(user, resetPasswordDTO.OldPassword);
            if (!isOldPasswordCorrect)
            {
                return BadRequest("Old password is incorrect.");
            }

            // Step 3: Ensure that the new password and confirm password match
            if (resetPasswordDTO.NewPassword != resetPasswordDTO.ConfirmPassword)
            {
                return BadRequest("New password and confirm password do not match.");
            }

            // Step 4: Update the password
            var result = await _userManager.ChangePasswordAsync(user, resetPasswordDTO.OldPassword, resetPasswordDTO.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Password has been reset successfully.");
        }

    }
}

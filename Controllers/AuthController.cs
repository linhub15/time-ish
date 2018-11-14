using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authorization;
// Prject References
using api.Infrastructure.DataAccess;
using api.Core.Entities;

namespace api.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TimeishContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(
            TimeishContext context, 
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<IdentityUser>> Users()
        {
            return _context.Users;
        }


        [Authorize]
        [HttpGet]
        public ActionResult<string> CurrentUser()
        {
            return HttpContext.User.Identity.Name;
        }

        [HttpPost]
        public async Task<object> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            
            var result = await _signInManager.PasswordSignInAsync(login.userName, login.password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(u => u.UserName == login.userName);
                return await GenerateJwtToken(login.userName, appUser);
            }

            return result;
        }

        [NonAction]
        private async Task<object> GenerateJwtToken(string userName, IdentityUser user)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public ActionResult<object> Register([FromBody] Register register)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = register.userName,
                Email = register.email
            };
            return _userManager.CreateAsync(user, register.password).Result;
        }
    }
}
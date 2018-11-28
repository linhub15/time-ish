using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Tymish.Core.DTOs;
using Tymish.Core.Interfaces;
using Tymish.Infrastructure.DataAccess;

namespace Tymish.Infrastructure.Authentication
{
    public class AuthenticationUtility : IAuthenticator<IdentityUser>
    {
        private readonly TimeishContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticationUtility(
            IConfiguration configuration,
            TimeishContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        } 

        public async Task<string> SignIn(LoginDTO user)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(user.userName, user.password, false, false);
            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(u => u.UserName == user.userName);
                return GenerateJwt(user.userName, appUser);
            }
            else 
            {
                return "Sign in failed";
            }
        }

        public void SignOut(LoginDTO user)
        {

        }

        public async Task<object> RegisterAdmin(RegisterAdminDTO admin)
        {
           IdentityUser user = new IdentityUser
            {
                UserName = admin.userName,
                Email = admin.email
            };
            return await _userManager.CreateAsync(user, admin.password);
        }


        private string GenerateJwt(string userName, IdentityUser user)
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
    }
}
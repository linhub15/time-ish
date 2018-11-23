using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// Project References
using Tymish.Core.DTOs;
using Tymish.Infrastructure.DataAccess;
using Tymish.Infrastructure.Authentication;

namespace Tymish.Api.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TimeishContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly AuthenticationUtility _authUtil;

        public AuthController(
            TimeishContext context, 
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            AuthenticationUtility authUtil)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _authUtil = authUtil;
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
        public async Task<object> Login([FromBody] LoginDTO login)
        {
            TryValidateModel(login);
            
            var result = await _signInManager.PasswordSignInAsync(login.userName, login.password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(u => u.UserName == login.userName);
                return  _authUtil.GenerateJwtToken(login.userName, appUser);
            }

            return result;
        }

        [HttpPost]
        public ActionResult<object> Register([FromBody] RegisterAdminDTO register)
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
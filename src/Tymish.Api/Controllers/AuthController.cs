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
            return await _authUtil.SignIn(login);
        }

        [HttpPost]
        public ActionResult<object> Register([FromBody] RegisterAdminDTO register)
        {
            TryValidateModel(register);
            return _authUtil.RegisterAdmin(register);
        }
    }
}
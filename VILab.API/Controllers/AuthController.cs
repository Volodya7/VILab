using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbModel.Entities;
using DbModel.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VILab.API.ExceptionFilters;
using VILab.API.Models;

namespace VILab.API.Controllers
{
    [AuthExceptionFilter]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private IVILabRepository _repository;
        private IConfigurationRoot _config;
        private SignInManager<ApplicationUser> _signInMng;
        private UserManager<ApplicationUser> _userMng;
        private IPasswordHasher<ApplicationUser> _hasher;
        private ILogger<AuthController> _logger;

        public AuthController(IVILabRepository repository,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IPasswordHasher<ApplicationUser> hasher,
            ILogger<AuthController> logger,
            IConfigurationRoot config)
        {
            _repository = repository;
            _signInMng = signInManager;
            _userMng = userManager;
            _hasher = hasher;
            _logger = logger;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CredentialsModel model)
        {
            try
            {
                var result = await _signInMng.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception thrown while logging in: {e}");
            }

            return BadRequest();
        }

    }
}

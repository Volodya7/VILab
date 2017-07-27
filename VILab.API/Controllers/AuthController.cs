using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DbModel.Entities;
using DbModel.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VILab.API.ExceptionFilters;
using VILab.API.Models;

namespace VILab.API.Controllers
{
  [EnableCors("SiteCorsPolicy")]
  [Route("api/auth")]
  public class AuthController : Controller
  {
    private IVILabRepository _repository;
    private SignInManager<ApplicationUser> _signInMng;
    private UserManager<ApplicationUser> _userMng;
    private IPasswordHasher<ApplicationUser> _hasher;
    private ILogger<AuthController> _logger;

    public AuthController(IVILabRepository repository,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IPasswordHasher<ApplicationUser> hasher,
        ILogger<AuthController> logger)
    {
      _repository = repository;
      _signInMng = signInManager;
      _userMng = userManager;
      _hasher = hasher;
      _logger = logger;
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

    [HttpPost("token")]
    public async Task<IActionResult> CreateToken([FromBody] CredentialsModel model)
    {
      try
      {
        var user = await _userMng.FindByNameAsync(model.UserName);
        if (user != null)
        {
          if (_hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) ==
              PasswordVerificationResult.Success)
          {
            var userClaims = await _userMng.GetClaimsAsync(user);

            var claims = new[]
            {
                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        }.Union(userClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.Configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Startup.Configuration["Tokens:Issuer"],
                audience: Startup.Configuration["Tokens:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds);

            _logger.LogInformation($"User {model.UserName} successfully logged in");

            return Ok(new
            {
              token = new JwtSecurityTokenHandler().WriteToken(token),
              expiration = token.ValidTo
            });
          }
        }
      }
      catch (Exception e)
      {
        _logger.LogError($"Exception thrown while creating JWT: {e}");
      }

      return BadRequest("Failed to generate token");
    }

  }
}

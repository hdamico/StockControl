using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ControlStock.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ControlStock.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;


        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return BuilToken(model);
                }
                else
                {
                    return BadRequest("Invalid Login");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return BuilToken(model);
                }
                else
                {
                    return BadRequest("Invalid Login");
                }
            }
            else
            {
                return BadRequest("Invalid Login 0");
            }
            // If we got this far, something failed, redisplay form

        }




        private IActionResult BuilToken(LoginViewModel model)
        {
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.UniqueName,model.Email),
               new Claim("miValor","Cualquiera"),
               new Claim("Admin","Y"),
               new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString())
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["MiKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "ISTEAprogramacionIII.com.ar"
                , audience: "ISTEAprogramacionIII.com.ar"
                , claims: claims
                , expires: expiration
                , signingCredentials: cred);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expira = expiration
            });
        }
    }
}
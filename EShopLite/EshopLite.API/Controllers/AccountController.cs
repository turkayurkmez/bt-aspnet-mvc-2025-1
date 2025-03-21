using EShopLite.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EshopLite.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController(IUserService userService) : ControllerBase    
    {
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(model.UserName, model.Password);
                if (user != null)
                {
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-guclu-ve-onemli_ve_cok_kritik"));
                    SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    };

                    var token = new JwtSecurityToken(
                        issuer: "server",
                        audience: "client",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddDays(7),
                        signingCredentials: signingCredentials

                         );

                    var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new { token = generatedToken  });

                }
            }
            return BadRequest(ModelState);

        }

    }

    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

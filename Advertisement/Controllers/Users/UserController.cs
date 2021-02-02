using advertisement.models;
using Advertisement.API.Application.Models;
using Advertisement.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Advertisement.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public UserController(IUserRepository userRepository,
                              IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(UserLoginModels user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            userRepository.Add(new User { Name = user.Name, Password = user.Password });
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginModels user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authUser = userRepository.GetAll()
                                         .FirstOrDefault(u => u.Name == user.Name
                                                           && u.Password == user.Password);

            if (authUser == null)
                return Unauthorized();

            var claims = getClaims(authUser);
            var token = getToken(claims);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        private IEnumerable<Claim> getClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };
        }

        private JwtSecurityToken getToken(IEnumerable<Claim> claims)
        {
            return new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                    SecurityAlgorithms.HmacSha256)
            );
        }
    }
}

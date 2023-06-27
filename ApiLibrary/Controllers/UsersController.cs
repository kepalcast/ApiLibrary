﻿using ApiLibrary.Models.Dto;
using ApiLibrary.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ApiLibrary.Repository.IRepository;

namespace ApiLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;

        public UsersController(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Login([FromBody] UserCreateDto userDto)
        {
            if (userDto == null)
                return BadRequest();

            string name = userDto.Name.ToString();
            string pass = userDto.Password.ToString();

            var user = await _userRepo.GetUser(name, pass);

            if (user == null)
                return NotFound();

            var jwt = _config.GetSection("Jwt").Get<Jwt>();

            // Crear los claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Crear el token
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(4),
                signingCredentials: credentials);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}

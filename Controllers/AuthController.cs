using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingAPI.Contracts;
using DatingAPI.Entities.DTOs;
using DatingAPI.Entities.Models;
using DatingAPI.Extensions;
using DatingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;

        public AuthController(IRepositoryWrapper repo, IMapper mapper, IConfiguration configuration,
            ILoggerManager logger)
        {
            _repo = repo;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.Trim().ToLower();
            var userIpAddress = Request.HttpContext.GetUserIpAddress();

            if (await _repo.Auth.UserExists(userForRegisterDto.Username))
            {
                _logger.LogWarn(
                    $"There was an attempt to create a new user with an existing username: '{userForRegisterDto.Username}'.",
                    userIpAddress);
                return BadRequest("Username already exists!");
            }

            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            _repo.Auth.Register(userToCreate, userForRegisterDto.Password);
            await _repo.SaveAsync();

            _logger.LogInfo($"User: {userForRegisterDto.Username} was created with success!", userIpAddress);

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var username = userForLoginDto.Username.Trim().ToLower();
            var userIpAddress = Request.HttpContext.GetUserIpAddress();

            var userFromRepo = await _repo.Auth.Login(username, userForLoginDto.Password);

            if (!await _repo.Auth.UserExists(username))
            {
                _logger.LogWarn($"There was an attempt to login with a non-existing username: '{username}' .",
                    userIpAddress);
                return BadRequest("The username you entered does not exist!");
            }

            if (userFromRepo == null)
            {
                _logger.LogWarn($"Failed login with username: {username}!", userIpAddress);
                return BadRequest("The password you entered is not correct!");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            _logger.LogInfo($"User: {username}, was logged in successfully!", userIpAddress);

            return Ok(new LoginResponse()
            {
                Name = username,
                Id = userFromRepo.Id,
                Token = tokenHandler.WriteToken(token)
            });
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web.Helpers;

namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        private IConfiguration _configuration;
        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            if(await _authRepository.UserExist(userForRegisterDto.UserName))
            {
                ModelState.AddModelError("UserName", "Username already exist");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = new User 
            { 
                UserName= userForRegisterDto.UserName,

            };

            var createdUser = await _authRepository.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
             var user = await _authRepository.Login(userForLoginDto.UserName, userForLoginDto.Password);
            if(user == null)
            {
                return Unauthorized();
            }
            var tokenHanlder = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
            };

            var token = tokenHanlder.CreateToken(tokenDescriptor);
            var tokenString = tokenHanlder.WriteToken(token);

            return Ok(tokenString);
            //return Ok(System.Text.Json.JsonSerializer.Serialize(tokenString));
            //return Ok(Json.stringify(tokenString));
            //return Ok(JsonConvert.SerializeObject(tokenString));
            //return Ok(new Value { Id= 1, Name="Azad"});
        }
    }
}

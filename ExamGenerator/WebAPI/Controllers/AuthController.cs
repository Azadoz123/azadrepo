using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.IdentityEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using DataAccess.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAccountService _accountService;
        private readonly IAuthDal _authDal;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService authService, IAccountService accountService, IAuthDal authDal, IConfiguration configuration)
        {
            _authService = authService;
            _accountService = accountService;
            _authDal = authDal;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public  IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            if (_authService.UserExists(userForRegisterDto.UserName))
            {
                ModelState.AddModelError("UserName", "Username already exist");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName
            };

            //var userToCreate = new CustomIdentityUser
            //{
            //    UserName = userForRegisterDto.UserName
            //};
            //var createdUser = _authService.Register(userToCreate, userForRegisterDto.Password);
            var createdUser = _authService.Register(userToCreate, userForRegisterDto.Password);


            if (createdUser != null)
            {
                //_accountService.Register(userForRegisterDto);

            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        public  IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var user = _authService.Login(userForLoginDto.UserName, userForLoginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            //var result = _authService.CreateAccessToken(user);

            //return Ok(result);
            return Ok();

        }
        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        //{
        //    if (await _authDal.UserExist(userForRegisterDto.UserName))
        //    {
        //        ModelState.AddModelError("UserName", "Username already exist");
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var userToCreate = new User
        //    {
        //        UserName = userForRegisterDto.UserName,

        //    };

        //    var createdUser = await _authDal.Register(userToCreate, userForRegisterDto.Password);
        //    return StatusCode(201);
        //}
        //[HttpPost("login")]
        //public async Task<ActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        //{
        //    var user = await _authDal.Login(userForLoginDto.UserName, userForLoginDto.Password);
        //    if (user == null)
        //    {
        //        return Unauthorized();
        //    }
        //    var tokenHanlder = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //            new Claim(ClaimTypes.Name, user.UserName)
        //        }),
        //        Expires = DateTime.Now.AddDays(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
        //    };

        //    var token = tokenHanlder.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHanlder.WriteToken(token);

        //      return Ok(tokenString);
        //  //  return Ok(System.Text.Json.JsonSerializer.Serialize(tokenString));
        //    //return Ok(Json.stringify(tokenString));
        //    //return Ok(JsonConvert.SerializeObject(tokenString));
        //    //return Ok(new Value { Id= 1, Name="Azad"});
        //}
    }
}

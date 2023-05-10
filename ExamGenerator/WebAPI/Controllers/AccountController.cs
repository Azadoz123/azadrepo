using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : CustomBaseController
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;
        private IAuthService _authService;
        private IConfiguration _configuration;
        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager, IAuthService authService, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _authService = authService;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        //[ValidateAntiForgeryToken]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            CustomIdentityUser user = new CustomIdentityUser
            {
                UserName = userForRegisterDto.UserName
            };

            IdentityResult result = _userManager.CreateAsync(user, userForRegisterDto.Password).Result;
           

            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("Admin").Result)
                {
                    CustomIdentityRole role = new CustomIdentityRole
                    {
                        Name = "Admin"
                    };

                    IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                    if (!roleResult.Succeeded)
                    {
                          ModelState.AddModelError("", "We can't add the role!");
                        //return Ok("Kayıt yapılmadı");

                        return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(500, Messages.NotRegistered));
                    }
                }

                _userManager.AddToRoleAsync(user, "Admin").Wait(); //NewUser

                var userToCreate = new User
                {
                    UserName = userForRegisterDto.UserName
                };
                //_authService.Register(userToCreate, userForRegisterDto.Password);
                //return Ok( "Kayıt yapıldı.");

                return CreateActionResult(CustomResponseDto<string>.Success(201,"Kayıt yapıldı."));
            }
            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(500,Messages.NotRegistered));
        }

        [HttpPost("Login")]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(userForLoginDto.UserName, userForLoginDto.Password, false, false).Result;
                if (result.Succeeded)
                {
                    //    return Ok("Giriş yapıldı.");
                    //}

                    //ModelState.AddModelError("", "Invalid login!");



                    var user = _userManager.Users.FirstOrDefault(x => x.UserName == userForLoginDto.UserName);
                    //var result2 = _authService.CreateAccessToken(user);
                    //return Ok("Giriş yapılamadı!");

                    if (user == null)
                    {
                        return CreateActionResult(CustomResponseDto<NoContent>.Fail(404, Messages.UserIsNotFound));
                    }
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);


                    //var rolesList = new List<string>{
                    // "Admin",
                    // "SuperUser",
                    // "Etc..."
                    // };
                    var roles = _roleManager.Roles.ToList();

                    //foreach (var role in rolesList)
                    //{
                    //    claims.Add(new Claim(ClaimTypes.Role, role));
                    //}
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "Admin")
                        }),
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    //return tokenString;
                    //   return Ok(tokenString);

                    return CreateActionResult(CustomResponseDto<string>.Success(200, tokenString));
                }
            }
            return CreateActionResult(CustomResponseDto<NoContent>.Fail(400, Messages.InvalidLogin));
        }

        [HttpGet("Logout")]
        //[ValidateAntiForgeryToken]
        public IActionResult Logout()
        {

           _signInManager.SignOutAsync().Wait();
            //return Ok("Çıkış yapıldı.");

            return CreateActionResult(CustomResponseDto<NoContent>.Success(200));
        }
    }
}

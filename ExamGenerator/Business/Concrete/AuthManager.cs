using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.IdentityEntities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business.Concrete
{
    public class AuthManager: IAuthService
    {
        private readonly IAuthDal _authDal;
        private readonly IConfiguration _configuration;

        public AuthManager(IAuthDal authDal, IConfiguration configuration)
        {
            _authDal = authDal;
            _configuration = configuration;
        }

        public string CreateAccessToken(CustomIdentityUser user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public User Login(string userName, string password)
        {
            var user = _authDal.Login(userName, password);
            if (user == null)
            {
                return null;
            }

            return user;

        }

        public User Register(User user, string password)
        {
            _authDal.Register(user, password);
            return user;
        }

        public bool UserExists(string userName)
        {
            return _authDal.UserExist(userName);
        }
    }
}

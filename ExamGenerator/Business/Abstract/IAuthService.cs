using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Entities.IdentityEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        //IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        //IDataResult<User> Login(UserForLoginDto userForLoginDto);
        //IResult UserExists(string email);
        //IDataResult<AccessToken> CreateAccessToken(User user);

        //User Register(User user, string password);
        User Register(User user, string password);
        bool UserExists(string userName);
        User Login(string userName, string password);
        string CreateAccessToken(CustomIdentityUser user);
    }
}

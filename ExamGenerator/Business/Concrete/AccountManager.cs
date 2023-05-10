using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.IdentityEntities;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;

        //public AccountManager(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    _signInManager = signInManager;
        //}

        public string Login(UserForLoginDto userForLoginDto)
        {
            //var result = _signInManager.PasswordSignInAsync(userForLoginDto.UserName, userForLoginDto.Password, false, false).Result;
            //if (result.Succeeded)
            //{
            //    return "Giriş yapıldı.";
            //}

            return "Giriş yapılamadı!";
        }

        public void Logout()
        {
            _signInManager.SignOutAsync().Wait();
        }

        public string Register(UserForRegisterDto userForRegisterDto)
        {
            //CustomIdentityUser user = new CustomIdentityUser
            //{
            //    UserName = userForRegisterDto.UserName
            //};

            //IdentityResult result = _userManager.CreateAsync(user, userForRegisterDto.Password).Result;

            //if (result.Succeeded)
            //{
            //    if (!_roleManager.RoleExistsAsync("Admin").Result)
            //    {
            //        CustomIdentityRole role = new CustomIdentityRole
            //        {
            //            Name = "Admin"
            //        };

            //        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

            //        if (!roleResult.Succeeded)
            //        {
            //            ModelState.AddModelError("", "We can't add the role!");
            //        }
            //    }

            //    _userManager.AddToRoleAsync(user, "NewUser").Wait(); //NewUser
            //    return "Kayıt yapıldı.";
            //}
            return "Kayıt yapılmadı";
        }
    }
}

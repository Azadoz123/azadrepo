﻿using Core6_App.Identity;
using Core6_App.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core6_App.Controllers
{
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;

        public SecurityController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {

                return View(loginViewModel);
            }
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Confirm Your Email, Please");
                    return View(loginViewModel);
                }
            }

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Login failed");
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {

                return View(registerViewModel);
            }

            var user = new AppIdentityUser
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                Age = registerViewModel.Age

            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);

                var callBackUrl = Url.Action("ConfirmEmail", "Security", new { userId = user.Id, code = confirmationCode.Result });

                //Send Email

                return RedirectToAction("Index", "Home");
            }

            return View(registerViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new ApplicationException("Unable to find the user");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View("ConfirmEmail");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return View();
            }

            var confirmationCode = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callBackUrl = Url.Action("ResetPassword", "Security", new { userId = user.Id, code = confirmationCode });

            //send callback Url with email

            return RedirectToAction("ForgotPasswordEmailSent");
        }

        public IActionResult ForgotPasswordEmailSent()
        {
            return View();
        }

        public IActionResult ResetPassword(string userId, string code)
        {
            if (userId == null || code == null)
            {
                throw new ApplicationException("User Id or Code must be supplied for password reset");
            }

            var model = new ResetPasswordViewModel
            {
                Code = code,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);

            if (user == null)
            {
                throw new ApplicationException("User not Found");
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirm");
            }

            return View();
        }

        public IActionResult ResetPasswordConfirm()
        {
            return View();
        }
    }         
}

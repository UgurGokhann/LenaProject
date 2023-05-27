using AutoMapper;
using FluentValidation;
using LenaProject.Business;
using LenaProject.Business.Interfaces;
using LenaProject.UI.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LenaProject.UI.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserRegisterDto> _userRegisterValidator;
        


        public AccountController(IUserService userService, IValidator<UserRegisterDto> userRegisterValidator)
        {
            _userService = userService;
            _userRegisterValidator = userRegisterValidator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var result = _userRegisterValidator.Validate(dto);
            if (result.IsValid)
            {

                var createResponse = await _userService.CreateUserAsync(dto);
                return this.ResponseRedirectAction(createResponse, "Login");

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(dto);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            
            var result = await _userService.CheckUserAsync(dto);
            if (result.ResponseType == DataAccess.Response.ResponseType.Success)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,dto.Username)

                };


                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));



                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");


            }

            ModelState.AddModelError("Username or password is wrong!", result.Message);
            return View(dto);

        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
           CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }

}

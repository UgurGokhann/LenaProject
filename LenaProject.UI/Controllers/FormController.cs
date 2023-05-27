using AutoMapper;
using FluentValidation;
using LenaProject.Business;
using LenaProject.Business.Interfaces;
using LenaProject.DataAccess.Response;
using LenaProject.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LenaProject.UI.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;
        private readonly IUserService _userService;
        private readonly IValidator<FormCreateDto> _formCreateDtoValidator;
        

        public FormController(IFormService formService, IValidator<FormCreateDto> formCreateDtoValidator, IUserService userService)
        {
            _formService = formService;
            _formCreateDtoValidator = formCreateDtoValidator;
            _userService = userService;
        }
        public IActionResult List()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FormCreateDto dto)
        {
            var response = _formCreateDtoValidator.Validate(dto);
            if (response.IsValid)
            {
                var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                var userResponse = await _userService.GetByIdAsync<UserListDto>(userId);

                if (userResponse.ResponseType == ResponseType.Success)
                {
                    dto.UserId = userResponse.Data.Id;
                }

                await _formService.CreateAsync(dto);

                return RedirectToAction("Index", "Home");
            }
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View();
            
        }
        public async Task<IActionResult> Detail(int id) 
        {
            var form = await _formService.GetFormByIdWithFields(id);
            return View(form);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _formService.RemoveAsync(id);
            return this.ResponseRedirectAction(response,"List");
        }
    }
}

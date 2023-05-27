using LenaProject.Business.Interfaces;
using LenaProject.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LenaProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFormService _formService;

        public HomeController(IFormService formService)
        {
            _formService = formService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewData["CurrentFilter"] = searchString;
                return View(await _formService.GetByForm(searchString));
            }
            
            return View(await _formService.GetAllFormsWithFields());
        }

       

        
    }
}

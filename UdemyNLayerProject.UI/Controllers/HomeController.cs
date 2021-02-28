using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.UI.DTOs;

namespace UdemyNLayerProject.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Error(ErrorDto errorDto)
        {
            return View(errorDto);
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
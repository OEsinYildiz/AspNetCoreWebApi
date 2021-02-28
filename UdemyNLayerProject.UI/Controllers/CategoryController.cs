using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.UI.DTOs;
using UdemyNLayerProject.UI.Filters;

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
        public async Task<IActionResult> Index()
        {
            ICollection<Category> categories = await _categoryService.GetAllAsync();
            return View(_mapper.Map<ICollection<CategoryDto>>(categories));
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            Category category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return RedirectToAction("Index");
        }
    }
}
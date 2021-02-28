using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<ICollection<ProductDto>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))] //Metot parametresi ID alan yerde kullanilir.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("{id}/category")]
        public async Task<IActionResult> ProductWithCategory(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product)); //Product donersen Categoryleri listelemez.
        }

        [HttpPost]
        [ValidationFilter] // Bunu controller seviyesinde de yazabilirsin
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.AddAsync(product); //sana product tipinde entity doner.
            return Created(string.Empty, _mapper.Map<ProductDto>(product));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }
    }
}
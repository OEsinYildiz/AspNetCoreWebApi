using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id =(int)context.ActionArguments.Values.FirstOrDefault(); //Action icerisinde aldgi degeri yakaliyoruz.

            Product product = await _productService.GetByIdAsync(id);

            if (product!=null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;
                errorDto.Errors.Add($"Id`si {id} olan urun bulunamamistir.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context) //Action islemi yapilirken mudahale etmek
        {
            if (!context.ModelState.IsValid) //herhangi bir property bos geldi ise
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(e => e.Errors);

                modelErrors.ToList().ForEach(x =>
                    errorDto.Errors.Add(x.ErrorMessage)
                );

                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Extentions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app) //Public ve static olmak zorunda
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    IExceptionHandlerFeature
                        error = context.Features.Get<IExceptionHandlerFeature>(); //Burada hatayi yakaladik
                    if (error != null)
                    {
                        Exception ex = error.Error;

                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add("Id bilgisi bulunamamistir.");
                        errorDto.Errors
                            .Add(ex.Message); //Kendi donus Dto umuza firlatilan hatalari ekledik. hatayi sen elle yazamazsin. Cunki Message set degil.
                        /*Burada List den gelen Add metodunu kullaniyoruz. */
                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(errorDto)); //Donusu Json olarak yaptik
                        /*
                         * Bu kisim Put metodu icin hazirlanmistir.
                         */
                    }
                });
            });
        }
    }
}
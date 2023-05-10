using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API._2.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException( this IApplicationBuilder app) 
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async contex =>
                {
                    contex.Response.ContentType = "application/json";

                    var exceptionFeature = contex.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClienSideException => 400,
                        NotFoundException=> 404,
                        _ => 500
                    };

                    contex.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    await contex.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}

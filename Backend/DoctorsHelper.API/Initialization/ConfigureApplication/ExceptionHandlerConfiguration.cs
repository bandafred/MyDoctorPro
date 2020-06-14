using System;
using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.BL.Core.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DoctorsHelper.API.Initialization.ConfigureApplication
{
    public static class ExceptionHandlerConfiguration
    {
        /// <summary>
        /// Применение настройки ExceptionHandler с использованием типизированного ответа в случае <see cref="Exception"/>.
        /// Ответ отдается в виде Json модели <see cref="ErrorListResponse"/>
        /// </summary>
        public static IApplicationBuilder UseExceptionHandlerWithJsonResponse(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    //TODO: Decide about status code for custom exceptions
                    context.Response.StatusCode = 500;

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    // Use exceptionHandlerPathFeature to process the exception (for example, 
                    // logging), but do NOT expose sensitive error information directly to 
                    // the client.
                    var e = exceptionHandlerPathFeature?.Error;

                    var errorList = e?.GetErrorListResponseFromException();

                    if (errorList != null)
                    {
                        var settings = new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        };
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorList, settings));
                    }
                });
            });

            return app;
        }
    }
}

using BindOpen.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// This class exposes extensions on exception.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Configures the specified .Net core service collection.
        /// </summary>
        /// <param name="app">The application builder to consider.</param>
        /// <param name="env">The environment to consider.</param>
        /// <param name="logger">The logger to consider.</param>
        public static void UseBindOpenExceptionHandler(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            ILogger logger)
        {
            app?.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionFeature?.Error;

                var problemDetails = new ProblemDetailsDto()
                {
                    RequestId = Activity.Current?.Id?.Substring(1, 25) ?? context.TraceIdentifier
                };
                if (env?.IsDevelopment() == true)
                {
                    problemDetails.Title = exception?.Message;
                    problemDetails.Detail = exception?.StackTrace;
                }
                else
                {
                    problemDetails.Title = "An exception occured on server side while executing the request";
                    problemDetails.Detail = "";
                }
                var problemDetailsList = new List<ProblemDetailsDto>()
                {
                    problemDetails
                };

                logger.LogError(exception?.Message + "-" + exception?.StackTrace);

                var result = JsonSerializer.Serialize(
                    problemDetailsList,
                    new JsonSerializerOptions()
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                    });
                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = 500;

                await context.Response.WriteAsync(result);
            }));
        }
    }
}
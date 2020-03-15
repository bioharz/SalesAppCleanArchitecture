﻿using System;
using System.Net;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CleanArchitecture.WebUI.Common
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Failures);
                    break;
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
                case DbUpdateException dbUpdateException:
                    const int PrimaryKeyConstraintViolationMsSqlExceptionNumber = 2627;
                    if (!(dbUpdateException.InnerException is SqlException)) break;
                    if ((dbUpdateException.InnerException as SqlException).Number !=
                        PrimaryKeyConstraintViolationMsSqlExceptionNumber) break;
                    code = HttpStatusCode.Conflict;
                    result = JsonConvert.SerializeObject(new DuplicateKeyException().Message);
                    break;
                    
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}

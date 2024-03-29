﻿using System;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using FCopr.Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FCorp.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
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
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case IncorrectAmountGoodsException incorrectAmountGoodsException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case IncorrectPriceException incorrectPriceException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case IncorrectStatusException incorrectStatusException:
                    code = HttpStatusCode.BadRequest;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
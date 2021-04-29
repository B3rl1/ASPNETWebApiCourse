using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AspNETWebAPI_Course.Data.ViewModels;
using Microsoft.AspNetCore.Http;

namespace AspNETWebAPI_Course.Exceptions
{
	public class CustomExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public CustomExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception e)
			{
				await HandleExceptionAsync(context, e);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, object o)
		{
			context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
			context.Response.ContentType = "application/json";

			var response = new ErrorVM()
			{
				StatusCode = context.Response.StatusCode,
				Message = "Internal Server Error from the custom middleware",
				Path = "path-goes-here"
			};

			return context.Response.WriteAsync(response.ToString());
		}
	}
}

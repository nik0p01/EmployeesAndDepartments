using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Data.Common;
using System.Net;
using System.Threading.Tasks;

namespace EmployeesDepartments
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = System.Net.HttpStatusCode.InternalServerError;

            if (ex is DbException)
                code = HttpStatusCode.InternalServerError;

            else if (ex is Exception)
                code = HttpStatusCode.InternalServerError;


            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}

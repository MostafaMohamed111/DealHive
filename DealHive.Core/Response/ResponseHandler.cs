using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hive.Core.Response
{
    public static class ResponseHandler<T> where T : class
    {
        public static Response<T> Delete() 
        {
            return new Response<T>()
            {

                httpStatusCode = HttpStatusCode.OK,
                Message = "Deleted"
            };
        }

        public static Response<T> Success(T? response = null, object? meta = null)
        {
            return new Response<T>()
            {
                httpStatusCode = HttpStatusCode.OK,
                Data = response,
                Message = "Succeeded",
                Meta = meta
            };
        }

        public static Response<T> Created(T entity, string? message)
        {
            return new Response<T>()
            {
                httpStatusCode = HttpStatusCode.OK,
                Data = entity,
                Message = message == null ? "Created Successfully" : message
            };
        }


        public static Response<T> UnAuthorized(string? message)
        {
            return new Response<T>()
            {
                httpStatusCode = HttpStatusCode.Unauthorized,
                Message = message == null ? "UnAuthorized" : message,
                Succeeded = false
            };
        }

        public static Response<T> BadRequest(string? message, List<string>? errors = null)
        {
            return new Response<T>()
            {
                httpStatusCode = HttpStatusCode.BadRequest,
                Message = message == null? "BadRequest" : message,
                Succeeded = false,
                Errors = errors

            };
        }

        public static Response<T> NotFound(string? message)
        {
            return new Response<T>()
            {
                httpStatusCode= HttpStatusCode.NotFound,
                Message = message == null? "NotFound" : message,
                Succeeded = false
            };
        }

        

    }
}

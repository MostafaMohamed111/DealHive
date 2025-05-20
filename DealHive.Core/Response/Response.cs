using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Core.Response
{
    public class Response<T> where T : class
    {
        public Response()
        {
            
        }
        public Response(T data, string? message = null)
        {
            Data = data;
            Message = message;
        }

        public Response(string? message = null)
        {
            Message = message;
        }



        public T? Data { get; set; }
        public object? Meta { get; set; }
        public string? Message { get; set; }
        public bool Succeeded { get; set; } = true;
        public HttpStatusCode httpStatusCode { get; set; }
        public List<string>? Errors { get; set; }


    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestApp.Domain.Constants;

namespace TestApp.Domain
{
    public class RequestHandler
    {
        public static string GetToken(HttpRequest request)
        {
            var headers = request.Headers;
            if (headers != null && headers.Count() > 0)
            {
                var tmp = headers.Where(s => s.Key.ToLower() == HeaderParam.Token.ToLower()).Select(s => s.Value.ToArray()).SingleOrDefault();
                return (tmp != null) ? tmp.ElementAt(0) : string.Empty;
            }
            return string.Empty;
        }

        public static string GetValue(HttpRequest request, string key)
        {
            var headers = request.Headers;
            if (headers != null && headers.Count() > 0)
            {
                var tmp = headers.Where(s => s.Key.ToLower() == key.ToLower()).Select(s => s.Value.ToArray()).SingleOrDefault();
                return (tmp != null) ? tmp.ElementAt(0) : string.Empty;
            }
            return string.Empty;
        }
        public static void ToInternalServerError<T>(APIResult<T>  response,string message="Error Occured")
        {
            response.Status.IsError = true;
            response.Status.ErrorCode = "500";
            response.Status.ErrorMessage = message;
        }
    }
}

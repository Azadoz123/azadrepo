using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extentions
{
    public static class JwtExtention
    {
        public static void AddApplicationError(this HttpResponse httpResponse, string message)
        {
            httpResponse.Headers.Add("Application-Error", message);
            httpResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            httpResponse.Headers.Add("Access-Control-Expose-Header", "Application-Error");
        }
    }
}

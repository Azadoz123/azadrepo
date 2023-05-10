using System.Security.Claims;
using System.Text;

namespace WebApiDemo.CustomMiddlewares
{
    public class AuthenticationMidlleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationMidlleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring(6).Trim();
                var credentialString = "";
                try
                {
                    credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                }
                catch
                {
                    context.Response.StatusCode = 500;

                }

                var credential = credentialString.Split(':');
                if (credential[0] == "engin" && credential[1] == "12345")
                {
                    var claims = new[] {
                        new Claim("name", credential[0]),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    context.User = new ClaimsPrincipal(identity);
                }
                }
                else
                {
                    context.Response.StatusCode = 401;
                }

            await _next(context);
        }
    }
}

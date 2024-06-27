using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_Web_Ejemplo.Controllers
{
    public class Ejemplo2Controller : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Ejemplo2Controller(IHttpContextAccessor contextAccessor) { 
            _contextAccessor = contextAccessor; 
        }

        [HttpGet("info_client")]
        public IActionResult getInfoClient() {

            var httpContext = _contextAccessor.HttpContext;

            var ipaddress = httpContext.Connection.RemoteIpAddress?.ToString();

            var userAgent = httpContext.Request.Headers["User-Agent"].ToString();

            var requestHeaders = httpContext.Request.Headers;
            var acceptHeaders = requestHeaders["Accept"].ToString();
            var languageHeaders = requestHeaders["Accept-Language"].ToString();
            var encodingHeaders = requestHeaders["Accept-Encoding"].ToString();
            var connectionHeaders = requestHeaders["Connection"].ToString();
            var forwardedHeaders = requestHeaders["Forwarded"].ToString();


            return Ok(new
                {
                    IpAddress = ipaddress,
                    UserAgent = userAgent,
                    AcceptHeaders = acceptHeaders,
                    LanguageHeaders = languageHeaders,
                    EncodingHeaders = encodingHeaders,
                    ConnectionHeaders = connectionHeaders,
                    ForwardedHeaders = forwardedHeaders,
                    RequestMethod = httpContext.Request.Method,
                    RequestPath = httpContext.Request.Path,
                    QueryString = httpContext.Request.QueryString.ToString()
            }
                );

        }

    }
}

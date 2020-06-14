using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace DoctorsHelper.BL.Core.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetJwtToken(this HttpContext httpContext, bool clearBearer = true)
        {
            string token = httpContext.Request.Headers[HeaderNames.Authorization];
            if (clearBearer)
                token = token.Replace("Bearer", "").TrimStart(':', ' ');

            return token;
        }
    }
}
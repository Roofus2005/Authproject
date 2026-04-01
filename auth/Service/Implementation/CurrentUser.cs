using auth.Service.Interface;
using System.Security.Claims;

namespace auth.Service.Implementation
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _http;

        public CurrentUser(IHttpContextAccessor http)
        {
            _http = http;
        }
        public string GetCurrentUser()
        {
            return _http.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
        }
    }
}

using System.Security.Claims;

namespace SwiftShop.Cart.SharedIdentity
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            //return _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;
            return _httpContextAccessor.HttpContext?
            .User?
            .FindFirst(ClaimTypes.NameIdentifier)?
            .Value;
        }
    }
}

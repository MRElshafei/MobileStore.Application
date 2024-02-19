using Microsoft.AspNetCore.Http;
using MobileStore.Application.Auth.JWT_Auth;

namespace Application.Helper
{
    public static class DecodingToken
    {
        public static long DecodingID(IHttpContextAccessor _contextAccessor)
        {
            return int.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(o => o.Type == JWTClaims.Id).Value);
        }
        public static string DecodingRoles(IHttpContextAccessor _contextAccessor)
        {
            var role = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(o => o.Type == JWTClaims.Roles);

            return (role.Value);
        }

    }
}

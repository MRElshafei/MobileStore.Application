using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Application.Auth.JWT_Auth
{
    public static class JWTClaims
    {
        public static string Id = "Id";
        public static string Email = "Email";
        public static string FirstName = "FirstName";
        public static string LastName = "LastName";
        public static string Role = "role";
        public static string Roles = ClaimTypes.Role;
    }
}

 using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MobileStore.Application.Auth.JWT_Auth
{
    public static class JWTHandler
    {
        public static async Task<JwtSecurityToken> CreateJwtToken(List<Claim> claims, JWT _jwt)
        {

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.secretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.issuer,
                audience: _jwt.audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.expiryMinutes),

                signingCredentials: signingCredentials);

            return await Task.FromResult(jwtSecurityToken);

        }
    }

}

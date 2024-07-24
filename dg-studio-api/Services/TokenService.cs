using dg_studio_api.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace dg_studio_api.Services
{
    public class TokenService
    {
        public static object GenerateToken(Usuarios usuario)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", usuario.id.ToString()),
                    new Claim("Categoria", usuario.categoria.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                           new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token =  tokenHandler.CreateToken(tokenConfig);
            return tokenHandler.WriteToken(token);
        }
        public static int? ReadJWT(string token)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                var claims = handler.ValidateToken(token, validations, out var tokenSecure);

                // Extraindo o claim 'userId' e convertendo para int
                var userIdClaim = claims.FindFirst("userId");
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }
            }
            catch
            {
                return 404;
            }

            return null; // Retorna null se o token não for válido ou o ID não puder ser extraído
        }

    }
}

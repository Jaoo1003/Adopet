using AdopetUsuario.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Adopet.Usuario.Services.Handler
{
    public class TokenService
    {
        public string GenerateToken(User usuario, string role)
        {
            Claim[] claims = new Claim[] {
                new Claim(ClaimTypes.Name, usuario.UserName),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim("LoginTimestamp", DateTime.Now.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gShqSHJMK4hyt$98¨#&*013h5g0´WR3hH9u-9h1u43$590hj"));

            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(8),
                claims: claims,
                signingCredentials: signinCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
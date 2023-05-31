using AdopetUsuario.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdopetUsuario.Services {
    public class TokenService {
        public void GenerateToken(Usuario usuario) {
            Claim[] claims = new Claim[] {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gShqSHJMK4hyt$98¨#&*013h5g0´WR3hH9u-9h1u43$590hj"));

            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(8),
                claims: claims,
                signingCredentials: signinCredentials
                );
        }
    }
}

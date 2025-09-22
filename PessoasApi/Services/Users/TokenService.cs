using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PessoasApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace PessoasApi.Services
{
    public class TokenService(IConfiguration configuration)
    {
    private readonly string _secretKey = configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("JWT Key não configurada");

        public string Generate(Users user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        );

        var claims = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "User")
        });

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2)
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}

}

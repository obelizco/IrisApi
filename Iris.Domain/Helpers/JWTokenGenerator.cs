using Iris.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Iris.Domain.Helpers;

public class JWTokenGenerator(IOptions<JWTOptions> _options)
{

    public string GenerateToken(string Id)
    {
        string key = _options.Value.SecretKey;
        string issuer = _options.Value.Issuer;
        string audience = _options.Value.Audience;
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(key));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
        Claim[] claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub,Id)
        };
        return new JwtSecurityTokenHandler()
        .WriteToken(
            new JwtSecurityToken(
             issuer: issuer,
             audience: audience,
             claims: claims,
             expires: DateTime.UtcNow.AddHours(12),
             signingCredentials: credentials
            )
        );
    }

}

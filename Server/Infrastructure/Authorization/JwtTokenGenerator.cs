using EslOnline.Application.Interfaces;
using EslOnline.Domain.Extensions;
using EslOnline.Infrastructure.Configuration;
using EslOnline.SharedKernel.Domain.Dto;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EslOnline.Infrastructure.Authorization;

public class JwtTokenGenerator(IOptions<JwtOptions> options) : ITokenGenerator
{
    public string GenerateToken(TokenData tokenData)
    {
        var subject = tokenData.ToClaimsIdentity();
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(options.Value.BearerKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = subject,
            //Issuer = options.Value.Issuer,
            //Audience = options.Value.Audience,
            Expires = DateTime.UtcNow.AddHours(options.Value.JwtTokenLife.Hours),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

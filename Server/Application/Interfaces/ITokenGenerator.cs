using EslOnline.SharedKernel.Domain.Dto;

namespace EslOnline.Application.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(TokenData data);
}

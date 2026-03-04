using Dapper;
using EslOnline.Application.Configurations;
using EslOnline.Application.Interfaces;
using EslOnline.Domain.Aggregates;
using EslOnline.Domain.Interfaces;
using EslOnline.Domain.Services;
using EslOnline.Domain.Specifications;
using EslOnline.SharedKernel.Application.Requests;
using EslOnline.SharedKernel.Application.Responses;
using EslOnline.SharedKernel.Domain.Dto;
using EslOnline.SharedKernel.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.Options;
using System.Data;

namespace EslOnline.Application.Handlers.Auth;

public class LoginWithGoogleHandler(
    IUnitOfWork unitOfWork,
    IAuthProvider authProvider,
    ITokenGenerator tokenGenerator,
    IRepository<User> userRepository,
    IOptions<GameBalance> options,
    UserRegistrationService userRegistrationService
    )
    : IRequestHandler<LoginWithGoogleRequest, LoginWithGoogleResponse>
{
    public async Task<LoginWithGoogleResponse> Handle(LoginWithGoogleRequest request, CancellationToken cancellationToken)
    {
        string accessToken = await authProvider.GetGoogleAccessTokenAsync(request.Code);
        (string email, string locale, string name, string? _) = await authProvider.GetGoogleUserinfoAsync(accessToken);

        await using var transaction = await unitOfWork.BeginTransactionAsync(IsolationLevel.Serializable);
        try
        {
            var userSpec = new UserSpecification(gmail: email);
            var existingUser = await userRepository.AnyAsync(userSpec, cancellationToken);
            if (!existingUser)
            {
                await userRegistrationService.RegisterNewUser(options.Value.MaxPopulationPerCity, name, locale, email);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            const string sqlReq = $@"
                SELECT 
                    u.Balance                AS {nameof(SqlDto.Balance)},
                    c.Name                   AS {nameof(SqlDto.CitizenName)},
                    g.Name                   AS {nameof(SqlDto.Citizenship)},
                    u.Language               AS {nameof(SqlDto.Local)},
                    u.ProfilePictureUrl      AS {nameof(SqlDto.PictureUrl)},
                    c.Id                     AS {nameof(SqlDto.CitizenIdGuid)}
                FROM [User] u
                JOIN Citizen c ON u.CitizenId = c.Id 
                JOIN Government g ON c.CitizenshipId = g.Id
                WHERE u.GMail = @Email";
            var sqlDto = await unitOfWork.Connection.QuerySingleAsync<SqlDto>(
                sql: sqlReq,
                param: new { Email = email },
                transaction: transaction.DbTransaction);
            var tokenData = new TokenData(sqlDto!.CitizenId);
            var token = tokenGenerator.GenerateToken(tokenData);
            await transaction.CommitAsync(cancellationToken);
            return new(
                token,
                sqlDto.CitizenName,
                sqlDto.Citizenship,
                sqlDto.Local,
                sqlDto.PictureUrl,
                sqlDto.CitizenId,
                sqlDto.Balance);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
    private sealed record SqlDto(
        int Balance,
        string CitizenName,
        string Citizenship,
        string Local,
        string? PictureUrl,
        Guid CitizenIdGuid
        )
    {
        public CitizenId CitizenId => new(CitizenIdGuid);
    }
}

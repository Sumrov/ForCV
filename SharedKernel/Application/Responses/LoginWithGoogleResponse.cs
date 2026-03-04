using EslOnline.SharedKernel.Application.Interfaces;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.SharedKernel.Application.Responses;

public sealed record LoginWithGoogleResponse(
    string JwtToken,
    string CitizenName,
    string Citizenship,
    string Local,
    string? PictureUrl,
    CitizenId CitizenId,
    int Balance
    )
    : IResponse;
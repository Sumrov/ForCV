using EslOnline.SharedKernel.Application.Interfaces;

namespace EslOnline.SharedKernel.Application.Responses;

public sealed record GetAuthorizationUrlResponse(string Url) : IResponse;

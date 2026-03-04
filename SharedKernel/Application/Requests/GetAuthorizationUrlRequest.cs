using EslOnline.SharedKernel.Application.Interfaces;
using EslOnline.SharedKernel.Application.Responses;
using EslOnline.SharedKernel.Domain.Enums;
using MediatR;

namespace EslOnline.SharedKernel.Application.Requests;

public sealed record GetAuthorizationUrlRequest(IdentityProvider IdentityProvider) : IRequest<GetAuthorizationUrlResponse>, IAnonymousRequest;


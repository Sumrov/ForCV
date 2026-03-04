using EslOnline.SharedKernel.Application.Interfaces;
using EslOnline.SharedKernel.Application.Responses;
using MediatR;

namespace EslOnline.SharedKernel.Application.Requests;

public sealed record LoginWithGoogleRequest(string Code) : IRequest<LoginWithGoogleResponse>, IAnonymousRequest;


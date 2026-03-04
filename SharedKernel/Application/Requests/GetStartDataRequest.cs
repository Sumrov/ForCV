using EslOnline.SharedKernel.Application.Interfaces;
using EslOnline.SharedKernel.Application.Responses;
using EslOnline.SharedKernel.Domain.ValueObjects;
using MediatR;

namespace EslOnline.SharedKernel.Application.Requests
{
    public sealed record GetStartDataRequest(CitizenId CitizenId) : IRequest<GetStartDataResponse>, ICitizenRequest;
}


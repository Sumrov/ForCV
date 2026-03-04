using EslOnline.Application.Interfaces;
using EslOnline.SharedKernel.Application.Requests;
using EslOnline.SharedKernel.Application.Responses;
using MediatR;

namespace EslOnline.Application.Handlers.Auth;

public class GetAuthorizationUrlHandler(IEnumerable<IAuthProvider> authProviders) : IRequestHandler<GetAuthorizationUrlRequest, GetAuthorizationUrlResponse>
{
    public async Task<GetAuthorizationUrlResponse> Handle(GetAuthorizationUrlRequest request, CancellationToken cancellationToken)
    {
        var provider = authProviders.FirstOrDefault(p => p.Provider == request.IdentityProvider)
            ?? throw new InvalidOperationException($"нет обработчика для провайдера {request.IdentityProvider}");

        var url = await provider.GetAuthorizationUrlAsync();

        return new GetAuthorizationUrlResponse(url);
    }
}
using EslOnline.SharedKernel.Application.Responses;
using EslOnline.SharedKernel.Domain.ValueObjects;
using MessagePipe;
using System;
using VContainer.Unity;

#nullable enable

namespace EslOnline.Infrastructure.Repositories;

public class InMemoryRepository : IDisposable, IInitializable
{
    public string? AccessToken { get; private set; }
    public CitizenId? CitizenId { get; private set; }

    private readonly ISubscriber<LoginWithGoogleResponse> _subLoginWithGoogle;
    private IDisposable? _disposable;

    public void Dispose() => _disposable?.Dispose();
    public bool IsAuthorized => !string.IsNullOrEmpty(AccessToken);

    public InMemoryRepository(
        ISubscriber<LoginWithGoogleResponse> subLoginWithGoogle
        )
    {
        _subLoginWithGoogle = subLoginWithGoogle;
    }

    public void Initialize()
    {
        var bag = DisposableBag.CreateBuilder();

        _subLoginWithGoogle
            .Subscribe(Handle)
            .AddTo(bag);

        _disposable = bag.Build();
    }

    private void Handle(LoginWithGoogleResponse notification)
    {
        AccessToken = notification.JwtToken;
        CitizenId = notification.CitizenId;
    }

    public void ClearAll()
    {
        AccessToken = null;
    }
}
using EslOnline.Infrastructure;
using EslOnline.Infrastructure.Extensions;
using EslOnline.Infrastructure.Repositories;
using EslOnline.Infrastructure.Repositories.ContentRepository;
using EslOnline.Infrastructure.ScriptableObjects;
using EslOnline.SharedKernel.Application;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace EslOnline.CompositionRoot
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private ClientSettingSO _clientSettings;
        [SerializeField] private ContentRepositoryDatabaseSO _repositoryDatabaseSO;

        protected override void Configure(IContainerBuilder builder)
        {
            InitLibraries(builder);
            InitInfrastructure(builder);
        }

        private void InitLibraries(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterAllPublishersByTypes(options, ApiRegistry.NotificationTypes.Values);
        }

        private void InitInfrastructure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_clientSettings);
            builder.RegisterInstance(_repositoryDatabaseSO);
            builder.Register<UnityHttpClient>(Lifetime.Singleton);
            builder.Register<NetworkService>(Lifetime.Singleton);
            builder.Register<GlobalErrorHandler>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<UnityClipboardReader>(Lifetime.Singleton);
            builder.Register<JwtTokenDecoder>(Lifetime.Singleton);
            builder.Register<SceneLoader>(Lifetime.Singleton);
            builder.Register<InMemoryRepository>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<ClipboardMonitor>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<ContentRepository>(Lifetime.Singleton);
        }
    }
}
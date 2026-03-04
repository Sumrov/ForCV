using Cysharp.Threading.Tasks;
using EslOnline.Infrastructure.Repositories;
using EslOnline.SharedKernel.Application.Notifications;
using EslOnline.SharedKernel.Application.Requests;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;
using MessagePipe;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EslOnline.Infrastructure;

public class SceneLoader
{
    private readonly IPublisher<SceneLoadingProgressNotification> _pubProgress;
    private readonly NetworkService _networkService;
    private readonly InMemoryRepository _inMemoryRepository;

    public SceneLoader(
        IPublisher<SceneLoadingProgressNotification> pubSceneLoadingProgress,
        NetworkService networkService,
        InMemoryRepository inMemoryRepository
        )
    {
        _pubProgress = pubSceneLoadingProgress;
        _networkService=networkService;
        _inMemoryRepository=inMemoryRepository;
    }

    public async UniTask LoadAsync(SceneName targetScene)
    {
        var operation = SceneManager.LoadSceneAsync(targetScene.ToString());

        if (operation == null) return;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            _pubProgress.Publish(new SceneLoadingProgressNotification(progress));
            await UniTask.Yield();
        }
        _pubProgress.Publish(new SceneLoadingProgressNotification(1f));

        if(targetScene == SceneName.GameScene)
        {
            if (_inMemoryRepository.CitizenId is not CitizenId citizenId)
            {
                throw new Exception(nameof(AppErrorCode.memory_repository_havent_citizenId));
            }
            await _networkService.SendAsync(new GetStartDataRequest(citizenId));
        }
    }
}
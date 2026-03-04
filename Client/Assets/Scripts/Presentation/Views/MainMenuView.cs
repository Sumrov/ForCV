using Cysharp.Threading.Tasks;
using EslOnline.Infrastructure;
using EslOnline.Infrastructure.Extensions;
using EslOnline.Infrastructure.ScriptableObjects;
using EslOnline.SharedKernel.Application.Requests;
using EslOnline.SharedKernel.Application.Responses;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.Exceptions;
using MessagePipe;
using System;
using System.Text.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

#nullable enable

namespace EslOnline.Presentation.Views
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _googleLoginButton = null!;
        [SerializeField] private Button _pasteTokenButton = null!;
        [SerializeField] private Button _enterButton = null!;
        [SerializeField] private Button _telegramButton = null!;
        [SerializeField] private TextMeshProUGUI _versionText = null!;

        private UnityClipboardReader _unityClipboardReader = null!;
        private SceneLoader _sceneLoader = null!;
        private ClientSettingSO _clientSettingSO = null!;
        private NetworkService _networkService = null!;
        private IPublisher<LoginWithGoogleResponse> _pubLoginWithGoogle = null!;
        private ISubscriber<LoginWithGoogleResponse> _subLoginWithGoogle = null!;
        private ISubscriber<GetAuthorizationUrlResponse> _subGetAuthorizationUrl = null!;
        private ISubscriber<AppExceptionDto> _subAppException = null!;
        private IDisposable? _disposable;

        private void OnDestroy() => _disposable?.Dispose();

        [Inject]
        public void Construct(
            UnityClipboardReader unityClipboardReader,
            SceneLoader sceneLoader,
            ClientSettingSO clientSettingSO,
            NetworkService networkService,
            IPublisher<LoginWithGoogleResponse> pubLoginWithGoogle,
            ISubscriber<LoginWithGoogleResponse> subLoginWithGoogle,
            ISubscriber<GetAuthorizationUrlResponse> subGetAuthorizationUrl,
            ISubscriber<AppExceptionDto> subAppException
            )
        {
            _unityClipboardReader = unityClipboardReader;
            _sceneLoader = sceneLoader;
            _clientSettingSO = clientSettingSO;
            _networkService = networkService;
            _pubLoginWithGoogle = pubLoginWithGoogle;
            _subLoginWithGoogle = subLoginWithGoogle;
            _subGetAuthorizationUrl = subGetAuthorizationUrl;
            _subAppException = subAppException;
        }

        private void Start()
        {
            var bag = DisposableBag.CreateBuilder();

            _subGetAuthorizationUrl
                .Subscribe(Handle)
                .AddTo(bag);

            _subLoginWithGoogle
                .Subscribe(Handle)
                .AddTo(bag);

            _subAppException
                .Subscribe(Handle)
                .AddTo(bag);

            if (string.IsNullOrEmpty(_clientSettingSO.GoogleAuthResponseString) == false)
                AuthHelper(_clientSettingSO.GoogleAuthResponseString);

            _disposable = bag.Build();
        }

        private void Awake()
        {
            _googleLoginButton.gameObject.SetActive(true);
            _pasteTokenButton.gameObject.SetActive(false);
            _enterButton.gameObject.SetActive(false);

            _googleLoginButton.onClick.AddListener(async () =>
            {
                _googleLoginButton.interactable = false;
                await _networkService.SendAsync(new GetAuthorizationUrlRequest(IdentityProvider.Google));
            });

            _pasteTokenButton.onClick.AddListener(() =>
            {
                if (_unityClipboardReader.TryRead(out var rawData) == false)
                    throw new Exception(nameof(AppErrorCode.login_google_response_deserialize_error));
                AuthHelper(rawData);
            });

            _enterButton.onClick.AddListener(async () => await _sceneLoader.LoadAsync(SceneName.GameScene));

            _telegramButton.onClick.AddListener(() => Application.OpenURL(_clientSettingSO.TelegramGroupUrl));

            _versionText.text = Application.version.ToVersionStatus();
        }

        private void AuthHelper(string authdata)
        {
            JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
            LoginWithGoogleResponse? response = JsonSerializer.Deserialize<LoginWithGoogleResponse>(authdata, jsonSerializerOptions);
            if (response == null) 
                throw new Exception(nameof(AppErrorCode.login_google_response_deserialize_error));
            _pubLoginWithGoogle.Publish(response);
        }

        private void Handle(GetAuthorizationUrlResponse notification)
        {
            Application.OpenURL(notification.Url);
        }

        private void Handle(LoginWithGoogleResponse notification)
        {
            _googleLoginButton.gameObject.SetActive(false);
            _enterButton.gameObject.SetActive(true);
            _pasteTokenButton.gameObject.SetActive(false);
        }

        private void Handle(AppExceptionDto notification)
        {
            _googleLoginButton.interactable = true;
            _pasteTokenButton.gameObject.SetActive(true);
        }
    }
}

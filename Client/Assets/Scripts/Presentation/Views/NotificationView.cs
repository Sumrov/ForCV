using DG.Tweening;
using EslOnline.SharedKernel.Application.Notifications;
using EslOnline.SharedKernel.Domain.Exceptions;
using MediatR;
using MessagePipe;
using System;
using TMPro;
using UnityEngine;
using VContainer;

#nullable enable

namespace EslOnline.Presentation.Views
{
    public class NotificationView : MonoBehaviour, IRequest
    {
        [SerializeField] private Transform _container = null!;
        [SerializeField] private Transform _defaultNotification = null!;
        [SerializeField] private Transform _redNotification = null!;

        private ISubscriber<BuildingClickNotification> _subBuildingClick = null!;
        private ISubscriber<AppExceptionDto> _subAppException = null!;
        private IDisposable? _disposable;

        private void OnDestroy() => _disposable?.Dispose();

        [Inject]
        public void Construct(
            ISubscriber<BuildingClickNotification> subBuildingClick,
            ISubscriber<AppExceptionDto> subAppException
            )
        {
            _subBuildingClick = subBuildingClick;
            _subAppException = subAppException;
        }

        private void Start()
        {
            var bag = DisposableBag.CreateBuilder();

            _subBuildingClick
                .Subscribe(Handle)
                .AddTo(bag);

            _subAppException
                .Subscribe(Handle)
                .AddTo(bag);

            _disposable = bag.Build();
        }

        private void Handle(AppExceptionDto notification)
        {
            ShowMessage(
                text: notification.ErrorCode.ToString(),
                prefab: _redNotification);
        }

        private void Handle(BuildingClickNotification notification)
        {
            ShowMessage(
                text: notification.NotificationText,
                prefab: _defaultNotification);
        }

        private void Awake()
        {
            _defaultNotification.GetComponent<CanvasGroup>().alpha = .0f;
            _redNotification.GetComponent<CanvasGroup>().alpha = .0f;
            _defaultNotification.gameObject.SetActive(false);
            _redNotification.gameObject.SetActive(false);
        }

        private void ShowMessage(string text, Transform prefab, float delay = 5f, float duration = 2f)
        {
            var instance = Instantiate(prefab, _container);
            var textMeshPro = instance.GetComponentInChildren<TextMeshProUGUI>();
            var canvasGroup = instance.GetComponent<CanvasGroup>();
            textMeshPro.text = text;
            DOTween.Sequence()
                    .AppendCallback(() => canvasGroup.alpha = 1f)
                    .AppendCallback(() => instance.gameObject.SetActive(true))
                    .AppendInterval(delay)
                    .Append(canvasGroup.DOFade(0f, duration))
                    .OnComplete(() => Destroy(instance.gameObject));
        }
    }
}
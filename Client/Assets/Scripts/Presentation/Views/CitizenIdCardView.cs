using DG.Tweening;
using EslOnline.Infrastructure;
using EslOnline.Infrastructure.Repositories;
using EslOnline.SharedKernel.Application.Responses;
using MessagePipe;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

#nullable enable

namespace EslOnline.Presentation.Views
{
    public class CitizenIdCardView : MonoBehaviour
    {
        [SerializeField] private Image _profileImage = null!;
        [SerializeField] private TextMeshProUGUI _cardIdText = null!;
        [SerializeField] private TextMeshProUGUI _nameText = null!;
        [SerializeField] private TextMeshProUGUI _citizenshipText = null!;
        [SerializeField] private CanvasGroup _canvasGroup = null!;

        private InMemoryRepository _inMemoryRepository = null!;
        private ISubscriber<LoginWithGoogleResponse> _subLoginWithGoogle = null!;
        private ISubscriber<GetStartDataResponse> _subGetStartData = null!;
        private IDisposable? _disposable;

        private void OnDestroy() => _disposable?.Dispose();

        [Inject]
        public void Construct(
            InMemoryRepository inMemoryRepository,
            ISubscriber<LoginWithGoogleResponse> subLoginWithGoogle,
            ISubscriber<GetStartDataResponse> subGetStartData
            )
        {
            _inMemoryRepository = inMemoryRepository;
            _subLoginWithGoogle = subLoginWithGoogle;
            _subGetStartData = subGetStartData;
        }

        private void Start()
        {
            var bag = DisposableBag.CreateBuilder();

            _subLoginWithGoogle
                .Subscribe(Handle)
                .AddTo(bag);

            _subGetStartData
                .Subscribe(Handle)
                .AddTo(bag);

            _disposable = bag.Build();
        }

        private void Handle(LoginWithGoogleResponse notification)
        {
            //_profileImage.sprite = notification.PictureUrl;
            _cardIdText.text = notification.CitizenId.Value.ToFastVisualId();
            _nameText.text = notification.CitizenName;
            _citizenshipText.text = notification.Citizenship;
            DOTween.Sequence()
                .Append(_canvasGroup.DOFade(1f, 1f));
        }

        private void Handle(GetStartDataResponse notification)
        {
            _cardIdText.text = _inMemoryRepository.CitizenId.Value.Value.ToFastVisualId();
            _nameText.text = notification.Name;
            _citizenshipText.text = notification.Citizenship;
            DOTween.Sequence()
                .Append(_canvasGroup.DOFade(1f, 1f));
        }

        private void Awake()
        {
            _canvasGroup.alpha = .0f;
        }
    }
}
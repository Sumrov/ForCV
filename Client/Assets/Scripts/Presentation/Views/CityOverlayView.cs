using DG.Tweening;
using EslOnline.Infrastructure.Repositories.ContentRepository;
using EslOnline.SharedKernel.Application.Responses;
using MessagePipe;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using static UnityEngine.GraphicsBuffer;

#nullable enable

namespace EslOnline.Presentation
{
    public class CityOverlayView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _productivityText = null!;
        [SerializeField] private TextMeshProUGUI _hungerText = null!;
        [SerializeField] private TextMeshProUGUI _stressText = null!;
        [SerializeField] private TextMeshProUGUI _health = null!;
        [SerializeField] private Image _baggageImage = null!;
        [SerializeField] private Button _buggageButton = null!;
        [SerializeField] private Button _locationButton = null!;
        [SerializeField] private Button _switchButton = null!;
        [SerializeField] private CanvasGroup _idCardCanvasGroup = null!;
        [SerializeField] private CanvasGroup _bankCardCanvasGroup = null!;

        private ContentRepository _contentRepository = null!;
        private ISubscriber<GetStartDataResponse> _subGetStartData = null!;
        private IDisposable? _disposable;

        private void OnDestroy() => _disposable?.Dispose();

        [Inject]
        public void Construct(
            ContentRepository contentRepository,
            ISubscriber<GetStartDataResponse> subGetStartData
            )
        {
            _contentRepository = contentRepository;
            _subGetStartData = subGetStartData;
        }

        private void Start()
        {
            var bag = DisposableBag.CreateBuilder();

            _subGetStartData
                .Subscribe(Handle)
                .AddTo(bag);

            _disposable = bag.Build();
        }

        private void Awake()
        {
            _idCardCanvasGroup.alpha = 1;
            _bankCardCanvasGroup.alpha = 0;

            _buggageButton.onClick.AddListener(() =>
            {
            });

            _locationButton.onClick.AddListener(() =>
            {
            });

            _switchButton.onClick.AddListener(() =>
            {
                float target = _idCardCanvasGroup.alpha > 0.5f ? 0f : 1f;

                _idCardCanvasGroup.DOFade(target, 0.5f);
                _bankCardCanvasGroup.DOFade(1f - target, 0.5f);
            });
        }

        private void Handle(GetStartDataResponse notification)
        {
            _productivityText.text = notification.Productivity.ToString();
            _hungerText.text = notification.Hunger.ToString();
            _stressText.text = notification.Stress.ToString();
            _health.text = notification.Health.ToString();
            _baggageImage.sprite = _contentRepository.GetSprite(o => o.GoodType == notification.CitizenBaggage);
        }
    }
}

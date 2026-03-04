using DG.Tweening;
using EslOnline.Infrastructure.Extensions;
using EslOnline.SharedKernel.Application.Responses;
using MessagePipe;
using System;
using TMPro;
using UnityEngine;
using VContainer;

#nullable enable

namespace EslOnline.Presentation.Views
{
    public class CitizenBankCardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyText = null!;
        [SerializeField] private TextMeshProUGUI _balanceText = null!;
        [SerializeField] private TextMeshProUGUI _ownerNameText = null!;
        [SerializeField] private TextMeshProUGUI _currentDataText = null!;
        [SerializeField] private CanvasGroup _canvasGroup = null!;

        private ISubscriber<GetStartDataResponse> _subGetStartData = null!;
        private IDisposable? _disposable;

        private void OnDestroy() => _disposable?.Dispose();

        [Inject]
        public void Construct(
            ISubscriber<GetStartDataResponse> subGetStartData
            )
        {
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

        private void Handle(GetStartDataResponse notification)
        {
            _currencyText.text = notification.CurrencyShortName;
            _balanceText.text = notification.Balance.ToString().SetBalanceFormatted();
            _ownerNameText.text = notification.Name;
            _currentDataText.text = DateTime.Now.ToShortDateString();
            DOTween.Sequence()
                .Append(_canvasGroup.DOFade(1f, 1f));
        }

        private void Awake()
        {
            _canvasGroup.alpha = .0f;
        }
    }
}
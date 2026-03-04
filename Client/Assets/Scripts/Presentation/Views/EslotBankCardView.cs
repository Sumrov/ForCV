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
    public class EslotBankCardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _balanceText = null!;
        [SerializeField] private TextMeshProUGUI _nameText = null!;
        [SerializeField] private TextMeshProUGUI _dateText = null!;
        [SerializeField] private CanvasGroup _canvasGroup = null!;

        private ISubscriber<LoginWithGoogleResponse> _subLoginWithGoogle = null!;
        private IDisposable? _disposable;

        private void OnDestroy() => _disposable?.Dispose();

        [Inject]
        public void Construct(
            ISubscriber<LoginWithGoogleResponse> subLoginWithGoogle)
        {
            _subLoginWithGoogle = subLoginWithGoogle;
        }

        private void Start()
        {
            var bag = DisposableBag.CreateBuilder();

            _subLoginWithGoogle
                .Subscribe(Handle)
                .AddTo(bag);

            _disposable = bag.Build();
        }

        private void Awake()
        {
            _canvasGroup.alpha = .0f;
        }

        private void Handle(LoginWithGoogleResponse notification)
        {
            _nameText.text = notification.CitizenName;
            _dateText.text = DateTime.UtcNow.ToShortDateString();
            //_balanceText.SetBalanceFormatted(notification.TokenData.ESLOTBalance);
            _balanceText.text = notification.Balance.SetBalanceFormatted();
            DOTween.Sequence()
                .Append(_canvasGroup.DOFade(1f, 1f));
        }
    }
}
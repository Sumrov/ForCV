using EslOnline.SharedKernel.Application.Responses;
using MessagePipe;
using System;
using UnityEngine;
using VContainer;

#nullable enable

namespace EslOnline.Presentation.Visuals
{
    public class CityVisual : MonoBehaviour
    {
        [SerializeField] private Transform _container = null!;

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

        }

        private void Awake()
        {

        }
    }
}

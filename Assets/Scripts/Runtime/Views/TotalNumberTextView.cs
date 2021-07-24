using System;
using UnityEngine;
using UnityEngine.UI;
using MessagePipe;
using VContainer;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View can't depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class TotalNumberTextView : MonoBehaviour
    {
        [Inject] private readonly IPresenterTotalCount presenter;
        [Inject] private readonly ISubscriber<CountType, int> subscriber;

        private Handler handler;
        private IDisposable subscription;

        private void Start()
        {
            var text = GetComponent<Text>();
            this.handler = new Handler(text, this.presenter);

            var bag = DisposableBag.CreateBuilder();
            this.subscriber.Subscribe(CountType.A, this.handler).AddTo(bag);
            this.subscriber.Subscribe(CountType.B, this.handler).AddTo(bag);
            this.subscription = bag.Build();

            this.handler.Handle(0); // Initialize
        }

        private void OnDestroy()
        {
            this.subscription.Dispose();
        }

        private class Handler : IMessageHandler<int>
        {
            private readonly Text text;
            private readonly IPresenterTotalCount presenter;

            public Handler(Text text, IPresenterTotalCount presenter)
            {
                this.text = text;
                this.presenter = presenter;
            }

            public void Handle(int message)
            {
                var total = this.presenter.GetTotalCount();
                this.text.text = string.Format("Total = {0}", total);
            }
        }
    }
}
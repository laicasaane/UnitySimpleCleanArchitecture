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
    public class ViewCountText : MonoBehaviour
    {
        public CountType Type;

        [Inject]
        private readonly ISubscriber<CountType, int> subscriber;

        private Handler handler;
        private IDisposable subscription;

        private void Start()
        {
            var text = GetComponent<Text>();
            this.handler = new Handler(this.Type, text);

            var bag = DisposableBag.CreateBuilder();
            this.subscriber.Subscribe(this.Type, this.handler).AddTo(bag);
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
            private readonly string type;

            public Handler(CountType type, Text text)
            {
                this.type = type.ToString();
                this.text = text;
            }

            public void Handle(int message)
            {
                this.text.text = string.Format("Count {0} = {1}", this.type, message);
            }
        }
    }
}
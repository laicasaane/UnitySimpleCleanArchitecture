using UnityEngine;
using MessagePipe;
using VContainer;

namespace SCA
{
    // Presenter
    // Presenter can depend on Usecase through its interface
    // Presenter can't dependent on View, Gateway
    // Presenter can inherit Monobehaviour
    public class PresenterCount : MonoBehaviour, IPresenterCount, IPresenterTotalCount
    {
        [Inject] private readonly IUsecaseCounter usecaseCounter;
        [Inject] private readonly IUsecaseTotalCounter usecaseTotalCounter;
        [Inject] private readonly IPublisher<CountType, int> publisher;

        private void Start()
        {
            // Connect callback event to reactive property
            this.usecaseCounter.OnCountChanged += OnCountChanged;
        }

        public int GetTotalCount()
        {
            return this.usecaseTotalCounter.GetTotalCount();
        }

        public void IncrementCount(CountType type)
        {
            this.usecaseCounter.IncrementCount(type);
        }

        void OnCountChanged(object sender, in CounterEventArgs arg)
        {
            this.publisher.Publish(arg.Type, arg.Count);
        }
    }
}
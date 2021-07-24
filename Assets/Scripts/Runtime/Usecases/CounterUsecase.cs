using System;
using VContainer;

namespace SCA
{
    // Usecase
    // Usecase can depend on Gateway through its interface.
    // Usecase can't be dependent on View, Presenter
    // Usecase can't inherit Monobehaviour
    public class CounterUsecase : ICounterUsecase
    {
        public ReadEventHandler<CounterEventArgs> OnCountChanged { get; set; }

        private readonly ICountDBGateway gateway;

        [Inject]
        public CounterUsecase(ICountDBGateway gateway)
        {
            this.gateway = gateway;
        }

        public void IncrementCount(CountType type)
        {
            var current = this.gateway.GetCount(type);
            var new_count = current + 1;
            this.gateway.SetCount(type, new_count);

            // publish the value changed
            this.OnCountChanged.Invoke(this, new CounterEventArgs(type, new_count));
        }
        public int GetCount(CountType type)
        {
            return this.gateway.GetCount(type);
        }
    }
}

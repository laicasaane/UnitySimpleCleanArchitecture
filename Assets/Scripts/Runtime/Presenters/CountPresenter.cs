using UnityEngine;
using UniRx;
using VContainer;

namespace SCA
{
    // Presenter
    // Presenter can depend on Usecase through its interface
    // Presenter can't dependent on View, Gateway
    // Presenter can inherit Monobehaviour
    public class CountPresenter : MonoBehaviour, ICountPresenter
    {
        public ReactiveProperty<int> CountA { get; private set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> CountB { get; private set; } = new ReactiveProperty<int>();

        private ICounterUsecase usecase;

        [Inject]
        public void Initialize(ICounterUsecase usecase)
        {
            this.usecase = usecase;

            // Connect callback event to reactive property
            this.usecase.OnCountChanged += OnCountChanged;
        }

        public void IncrementCount(CountType type)
        {
            this.usecase.IncrementCount(type);
        }

        void OnCountChanged(object sender, in CounterEventArgs arg)
        {
            if(arg.Type == CountType.A)
            {
                this.CountA.Value = arg.Count;
            }
            else if (arg.Type == CountType.B)
            {
                this.CountB.Value = arg.Count;
            }
        }
    }
}
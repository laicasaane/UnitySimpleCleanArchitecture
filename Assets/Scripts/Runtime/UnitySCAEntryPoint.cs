using VContainer;
using VContainer.Unity;

namespace SCA
{
    public class UnitySCAEntryPoint : IStartable
    {
        [Inject] private readonly ICounterUsecase usecase;
        [Inject] private readonly CountPresenter presenter;

        void IStartable.Start()
        {
            this.presenter.Initialize(this.usecase);
        }
    }
}

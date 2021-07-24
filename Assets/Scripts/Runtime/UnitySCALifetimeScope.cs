using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SCA
{
    public class UnitySCALifetimeScope : LifetimeScope
    {
        [SerializeField]
        private Transform transformCanvas;

        protected override void Configure(IContainerBuilder builder)
        {
            var presenter = this.gameObject.AddComponent<CountPresenter>();

            builder.Register<ICountDBGateway, CountDBGateway>(Lifetime.Scoped);
            builder.Register<ICounterUsecase, CounterUsecase>(Lifetime.Scoped);
            builder.RegisterComponent(presenter).As<ICountPresenter>();

            builder.RegisterEntryPoint<UnitySCAEntryPoint>();
        }
    }
}
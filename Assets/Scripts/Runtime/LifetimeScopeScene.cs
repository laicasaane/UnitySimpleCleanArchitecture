using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace SCA
{
    public class LifetimeScopeScene : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<CountType, int>(options);

            builder.Register<GatewayCountDB>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<UsecaseCounter>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<UsecaseTotalCounter>(Lifetime.Scoped).AsImplementedInterfaces();

            var presenter = this.gameObject.AddComponent<PresenterCount>();
            builder.RegisterComponent(presenter).AsSelf().AsImplementedInterfaces();
        }
    }
}
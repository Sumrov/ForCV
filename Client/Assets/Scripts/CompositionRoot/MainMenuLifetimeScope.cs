using VContainer;
using VContainer.Unity;

namespace EslOnline.CompositionRoot
{
    public class MainMenuLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //builder.RegisterComponentInHierarchy<MainMenuView>().AsImplementedInterfaces().AsSelf();
        }
    }
}
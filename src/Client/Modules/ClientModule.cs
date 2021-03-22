using Autofac;

namespace Client.Modules
{
    public class ClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>();
            base.Load(builder);
        }
    }
}
using System.Windows;
using Autofac;
using Client.Modules;

namespace Client
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new ContainerBuilder();
            container.RegisterModule<ClientModule>();

            using (var scope = container.Build())
            {
                var window = scope.Resolve<MainWindow>();
                window.Show();
            }

            base.OnStartup(e);
        }
    }
}
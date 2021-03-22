using System.Windows;
using Prism.Ioc;
using Prism.Unity;

namespace Client
{
    internal class Bootstrapper : PrismBootstrapper
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        protected override void InitializeShell(DependencyObject shell)
        {
            Application.Current.MainWindow = (Window) shell;
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Show();
            }
        }

        protected override DependencyObject CreateShell() =>
            Container.Resolve<MainWindow>();
    }
}
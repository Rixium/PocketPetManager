using System.Windows;
using Client.Builders;
using Client.Views;
using Client.Modules;
using Client.Services;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;

namespace Client.Startup
{
    internal class Bootstrapper : PrismBootstrapper
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IItemService, ItemService>();
            containerRegistry.Register<IItemBuilder, ItemBuilder>();
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

        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => Container.Resolve(type));
            base.ConfigureViewModelLocator();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var moduleLocatorType = typeof(ModuleLocators);
            moduleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = moduleLocatorType.Name,
                ModuleType = moduleLocatorType.AssemblyQualifiedName
            });
        }
    }
}
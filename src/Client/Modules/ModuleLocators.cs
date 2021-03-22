using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Client.Modules
{
    internal class ModuleLocators : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleLocators(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider) =>
            _regionManager.RegisterViewWithRegion("Shell", typeof(Views.Welcome));

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
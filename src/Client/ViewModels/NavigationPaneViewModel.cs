using Client.Views;
using JetBrains.Annotations;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Client.ViewModels
{
    [UsedImplicitly]
    internal class NavigationPaneViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand CreateNewPetCommand =>
            new(() => _regionManager.RequestNavigate("Shell", nameof(NewPet)));

        public NavigationPaneViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
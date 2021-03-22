using System;
using Client.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Client.ViewModels
{
    public class WelcomeViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public WelcomeViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public DelegateCommand CreateNewPetCommand =>
            new(() => _regionManager.RequestNavigate("Shell", nameof(NewPet)));
    }
}
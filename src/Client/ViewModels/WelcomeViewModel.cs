using System;
using Client.Persistence;
using Client.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Client.ViewModels
{
    public class WelcomeViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IItemStore _itemStore;

        public WelcomeViewModel(IRegionManager regionManager, IItemStore itemStore)
        {
            _regionManager = regionManager;
            _itemStore = itemStore;
            
            _itemStore.Create("myitemstore.json");
            _itemStore.Read();
        }

        public DelegateCommand CreateNewPetCommand =>
            new(() => _regionManager.RequestNavigate("Shell", nameof(NewPet)));
    }
}
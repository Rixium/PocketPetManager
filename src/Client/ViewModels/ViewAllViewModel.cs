using System.Collections.Generic;
using System.Linq;
using Client.Models;
using Client.Services;
using Client.Views;
using JetBrains.Annotations;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Client.ViewModels
{
    [UsedImplicitly]
    internal class ViewAllViewModel : BindableBase
    {
        private readonly IItemService _itemService;
        private readonly IRegionManager _regionManager;

        public int SelectedItem { get; set; }
        private IReadOnlyCollection<Item> _items;

        public IReadOnlyCollection<Item> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public DelegateCommand Refresh => new(() => Items = _itemService.GetItems());

        public DelegateCommand EditItemCommand => new(EditSelectedItem);

        public ViewAllViewModel(IItemService itemService, IRegionManager regionManager)
        {
            _itemService = itemService;
            _regionManager = regionManager;
        }

        private void EditSelectedItem()
        {
            var navigationParameters = new NavigationParameters();
            var selectedItem = _items.ElementAt(SelectedItem);
            navigationParameters.Add("Item", selectedItem);
            _regionManager.RequestNavigate("Shell", nameof(NewPet), navigationParameters);
        }
    }
}
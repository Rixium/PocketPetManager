using System.Collections.Generic;
using Client.Models;
using Client.Services;
using JetBrains.Annotations;
using Prism.Commands;
using Prism.Mvvm;

namespace Client.ViewModels
{
    [UsedImplicitly]
    internal class ViewAllViewModel : BindableBase
    {
        private readonly IItemService _itemService;

        public ViewAllViewModel(IItemService itemService) => _itemService = itemService;

        private IReadOnlyCollection<Item> _items;

        public IReadOnlyCollection<Item> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public DelegateCommand Refresh => new DelegateCommand(() => Items = _itemService.GetItems());
    }
}
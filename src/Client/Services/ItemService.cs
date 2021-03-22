using System.Collections.Generic;
using Client.Builders;
using Client.Models;
using Client.Persistence;
using JetBrains.Annotations;

namespace Client.Services
{
    [UsedImplicitly]
    internal class ItemService : IItemService
    {
        private readonly IItemStore _itemStore;

        public ItemService(IItemStore itemStore)
        {
            _itemStore = itemStore;
        }

        public IReadOnlyCollection<Item> GetItems() => _itemStore.Get();

        public void CreateNewItem(IItemBuilder itemBuilder)
        {
            var items = GetItems();

            itemBuilder.SetItemId(items.Count + 1);

            var item = itemBuilder.Build();
            _itemStore.Add(item);
        }
    }
}
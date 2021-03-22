using System.Collections.Generic;
using System.Linq;
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

            itemBuilder.SetItemId(items.Count + 1, false);

            var newItem = itemBuilder.Build();

            if (GetItems().Any(item => item.ItemId == newItem.ItemId))
            {
                _itemStore.Update(newItem);
                return;
            }

            _itemStore.Add(newItem);
        }

        public void DeleteItem(Item item) => _itemStore.Delete(item);
    }
}
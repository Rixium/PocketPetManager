using System.Collections.Generic;
using Client.Builders;
using Client.Models;

namespace Client.Services
{
    public interface IItemService
    {
        IReadOnlyCollection<Item> GetItems();
        void CreateNewItem(IItemBuilder itemBuilder);
        void DeleteItem(Item item);
    }
}
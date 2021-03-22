using Client.Builders;
using JetBrains.Annotations;

namespace Client.Services
{
    [UsedImplicitly]
    internal class ItemService : IItemService
    {
        public void CreateNewItem(IItemBuilder itemBuilder)
        {
            var item = itemBuilder.Build();
        }
    }
}
using Client.Builders;

namespace Client.Services
{
    public interface IItemService
    {
        void CreateNewItem(IItemBuilder itemBuilder);
    }
}
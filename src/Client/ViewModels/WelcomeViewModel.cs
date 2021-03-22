using Client.Persistence;
using JetBrains.Annotations;
using Prism.Mvvm;

namespace Client.ViewModels
{
    [UsedImplicitly]
    public class WelcomeViewModel : BindableBase
    {
        public WelcomeViewModel(IItemStore itemStore)
        {
            itemStore.Create("myitemstore.json");
            itemStore.Read();
        }
    }
}
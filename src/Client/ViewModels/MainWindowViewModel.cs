using Client.Persistence;
using JetBrains.Annotations;
using Microsoft.Win32;
using Prism.Commands;

namespace Client.ViewModels
{
    [UsedImplicitly]
    internal class MainWindowViewModel
    {
        private readonly IItemStore _itemStore;
        public DelegateCommand LoadItemsCommand => new(LoadItems);
        public DelegateCommand SaveAsJsonCommand => new(SaveAsJson);
        public DelegateCommand ExportAsLuaCommand => new(ExportAsLua);

        public MainWindowViewModel(IItemStore itemStore)
        {
            _itemStore = itemStore;
        }

        private void LoadItems()
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".json",
                Filter = "JSON text documents (.json) | *.json"
            };

            var result = dialog.ShowDialog();

            if (result != true) return;

            var filename = dialog.FileName;
            _itemStore.ReadFromFile(filename);
        }

        private void SaveAsJson()
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = ".json",
                Filter = "JSON text documents (.json) | *.json"
            };

            var result = dialog.ShowDialog();

            if (result != true) return;

            var filename = dialog.FileName;
            _itemStore.SaveToFile(filename);
        }

        private void ExportAsLua()
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = ".lua",
                Filter = "Lua file (.lua) | *.lua"
            };

            var result = dialog.ShowDialog();

            if (result != true) return;

            var filename = dialog.FileName;
            _itemStore.SaveAsLua(filename);
        }
    }
}
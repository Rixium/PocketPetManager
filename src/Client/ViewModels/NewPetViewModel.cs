using System.Linq;
using Client.Builders;
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
    internal class NewPetViewModel : BindableBase, INavigationAware
    {
        private IItemBuilder _itemBuilder;
        private readonly IItemService _itemService;

        public static string[] ItemTypes => new[]
        {
            "",
            "Seed",
            "Pet",
            "Coin"
        };

        public static string[] PetTypes => new[]
        {
            "",
            "Pixie",
            "Cool",
            "Brute"
        };

        private int _selectedItemType;

        public int SelectedItemType
        {
            get => _selectedItemType;
            set
            {
                if (!SetProperty(ref _selectedItemType, value))
                {
                    return;
                }

                _itemBuilder.SetItemType(ItemTypes.ElementAt(value));
                RaisePropertyChanged(nameof(ItemPropertiesAreVisible));
                RaisePropertyChanged(nameof(PetPropertiesAreVisible));
            }
        }

        private string _itemName = "";

        public string ItemName
        {
            get => _itemName;
            set
            {
                if (SetProperty(ref _itemName, value))
                {
                    _itemBuilder.SetName(value);
                }
            }
        }

        private int _selectedPetType;

        public int SelectedPetType
        {
            get => _selectedPetType;
            set
            {
                if (SetProperty(ref _selectedPetType, value))
                {
                    _itemBuilder.SetType(PetTypes.ElementAt(value));
                }
            }
        }

        private string _description = "";

        public string Description
        {
            get => _description;
            set
            {
                if (SetProperty(ref _description, value))
                {
                    _itemBuilder.SetDescription(value);
                }
            }
        }

        private string _modelId = "";

        public string ModelId
        {
            get => _modelId;
            set
            {
                if (SetProperty(ref _modelId, value))
                {
                    _itemBuilder.SetModelId(value);
                }
            }
        }

        private string _experienceToLevel = "";

        public string ExperienceToLevel
        {
            get => _experienceToLevel;
            set
            {
                if (SetProperty(ref _experienceToLevel, value))
                {
                    _itemBuilder.SetExperienceToLevel(value);
                }
            }
        }

        private string _coinValue = "";

        public string CoinValue
        {
            get => _coinValue;
            set
            {
                if (SetProperty(ref _coinValue, value))
                {
                    _itemBuilder.SetValue(value);
                }
            }
        }

        private string _levelToEvolution = "";

        public string LevelToEvolution
        {
            get => _levelToEvolution;
            set
            {
                if (SetProperty(ref _levelToEvolution, value))
                {
                    _itemBuilder.SetLevelToEvolve(value);
                }
            }
        }

        public bool ItemPropertiesAreVisible => ItemTypes[_selectedItemType] == "Coin";

        public bool PetPropertiesAreVisible => ItemTypes[_selectedItemType] == "Pet" ||
                                               ItemTypes[_selectedItemType] == "Seed";

        public DelegateCommand SelectEvolutionCommand => new(() => { });

        public DelegateCommand SaveItemCommand => new(SaveItem);

        public NewPetViewModel(IItemBuilder itemBuilder, IItemService itemService)
        {
            _itemBuilder = itemBuilder;
            _itemService = itemService;
        }

        private void SaveItem() => _itemService.CreateNewItem(_itemBuilder);

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters["Item"] == null)
            {
                return;
            }

            var item = (Item) navigationContext.Parameters["Item"];
            _itemBuilder.SetItemId(item.ItemId, true);
            ItemName = item.Name;
            Description = item.Description;
            ExperienceToLevel = item.ExperienceToLevel.ToString();
            ModelId = item.ModelId.ToString();
            LevelToEvolution = item.LevelToEvolve.ToString();

            SelectedPetType = PetTypes.ToList().IndexOf(item.Type);
            SelectedItemType = ItemTypes.ToList().IndexOf(item.ItemType);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) =>
            navigationContext.Uri.ToString() == nameof(NewPet);

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
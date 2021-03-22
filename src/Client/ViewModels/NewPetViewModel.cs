using Client.Builders;
using Client.Services;
using JetBrains.Annotations;
using Prism.Commands;
using Prism.Mvvm;

namespace Client.ViewModels
{
    [UsedImplicitly]
    internal class NewPetViewModel : BindableBase
    {
        private readonly IItemBuilder _itemBuilder;
        private readonly IItemService _itemService;

        public static string[] ItemTypes => new[]
        {
            "Seed",
            "Pet",
            "Coin"
        };

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

        public static string[] PetTypes => new[]
        {
            "Pixie",
            "Cool",
            "Brute"
        };

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

        public DelegateCommand SelectEvolutionCommand => new(() => { });

        public DelegateCommand SaveItemCommand => new(SaveItem);

        public NewPetViewModel(IItemBuilder itemBuilder, IItemService itemService)
        {
            _itemBuilder = itemBuilder;
            _itemService = itemService;
        }

        private void SaveItem() => _itemService.CreateNewItem(_itemBuilder);
    }
}
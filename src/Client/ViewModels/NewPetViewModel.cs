﻿using System.Linq;
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
                if (SetProperty(ref _selectedItemType, value))
                {
                    _itemBuilder.SetItemType(ItemTypes.ElementAt(value));
                }
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
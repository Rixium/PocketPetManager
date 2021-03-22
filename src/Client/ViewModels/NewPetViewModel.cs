using System;
using Prism.Commands;
using Prism.Mvvm;

namespace Client.ViewModels
{
    internal class NewPetViewModel : BindableBase
    {
        public static string[] ItemTypes => new[]
        {
            "Seed",
            "Pet",
            "Coin"
        };

        public string ItemName { get; set; }

        public static string[] PetTypes => new[]
        {
            "Pixie",
            "Cool",
            "Brute"
        };

        public string Description { get; set; }

        public string ModelId { get; set; }

        public string ExperienceToLevel { get; set; }

        public string LevelToEvolution { get; set; }
        
        public DelegateCommand SelectEvolutionCommand => new(() => { });

        public DelegateCommand SaveItemCommand => new(SaveItem);

        private void SaveItem()
        {
            Console.WriteLine("SAVING");
        }
    }
}
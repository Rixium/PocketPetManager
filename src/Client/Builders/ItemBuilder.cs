using Client.Models;
using JetBrains.Annotations;

namespace Client.Builders
{
    [UsedImplicitly]
    public class ItemBuilder : IItemBuilder
    {
        private int _id;
        private string _itemType;
        private string _name;
        private string _type;
        private string _description;
        private int? _modelId;
        private int? _experienceToLevel;
        private int? _levelToEvolve;
        private int? _evolvesTo;

        public void SetItemId(int id) => _id = id;

        public void SetItemType(string type) => _itemType = type;

        public void SetName(string name) => _name = name;

        public void SetType(string type) => _type = type;

        public void SetDescription(string description) => _description = description;

        public void SetModelId(string modelId) => _modelId = Parse(modelId);

        public void SetExperienceToLevel(string experienceToLevel) => _experienceToLevel = Parse(experienceToLevel);

        public void SetLevelToEvolve(string levelToEvolve) => _levelToEvolve = Parse(levelToEvolve);

        public void SetEvolvesTo(string evolvesTo) => _evolvesTo = Parse(evolvesTo);

        public Item Build() =>
            new Item
            {
                ItemId = _id,
                ItemType = _itemType,
                Name = _name,
                Type = _type,
                Description = _description,
                ModelId = _modelId,
                ExperienceToLevel = _experienceToLevel,
                LevelToEvolve = _levelToEvolve,
                EvolvesTo = _evolvesTo
            };

        private static int? Parse(string s)
        {
            var parsed = int.TryParse(s, out var result);

            if (!parsed)
            {
                return null;
            }

            return result;
        }
    }
}
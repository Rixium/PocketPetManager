using System;
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
        private long? _modelId;
        private long? _experienceToLevel;
        private long? _levelToEvolve;
        private long? _evolvesTo;
        private int? _value;

        public void SetItemId(int id, bool overwrite)
        {
            if (!overwrite && _id != 0)
            {
                return;
            }

            _id = id;
        }

        public void SetItemType(string type) => _itemType = type;

        public void SetName(string name) => _name = name;

        public void SetType(string type) => _type = type;

        public void SetDescription(string description) => _description = description;

        public void SetModelId(string modelId) => _modelId = ParseLong(modelId);

        public void SetExperienceToLevel(string experienceToLevel) => _experienceToLevel = ParseLong(experienceToLevel);

        public void SetLevelToEvolve(string levelToEvolve) => _levelToEvolve = ParseLong(levelToEvolve);

        public void SetEvolvesTo(string evolvesTo) => _evolvesTo = ParseLong(evolvesTo);

        public void SetValue(string value) => _value = ParseInt(value);

        public Item Build()
        {
            var newItem = new Item
            {
                ItemId = _id,
                ItemType = _itemType,
                Name = _name,
                Type = _type,
                Description = _description,
                ModelId = _modelId,
                ExperienceToLevel = _experienceToLevel,
                LevelToEvolve = _levelToEvolve,
                EvolvesTo = _evolvesTo, 
                Value = _value
            };

            _id = 0;

            return newItem;
        }

        private static long? ParseLong(string s)
        {
            var parsed = long.TryParse(s, out var result);

            if (!parsed)
            {
                return null;
            }

            return result;
        }

        private static int? ParseInt(string s)
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
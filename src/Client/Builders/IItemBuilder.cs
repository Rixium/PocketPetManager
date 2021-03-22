using Client.Models;

namespace Client.Builders
{
    public interface IItemBuilder
    {
        void SetItemId(int id, bool overwrite);
        void SetItemType(string type);
        void SetName(string name);
        void SetType(string type);
        void SetDescription(string description);
        void SetModelId(string modelId);
        void SetExperienceToLevel(string experienceToLevel);
        void SetLevelToEvolve(string levelToEvolve);
        void SetEvolvesTo(string evolvesTo);
        void SetValue(string value);
        Item Build();
    }
}
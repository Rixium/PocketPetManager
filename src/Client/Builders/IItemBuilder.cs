using Client.Models;

namespace Client.Builders
{
    public interface IItemBuilder
    {
        void SetItemType(string type);
        void SetName(string name);
        void SetType(string type);
        void SetDescription(string description);
        void SetModelId(string modelId);
        void SetExperienceToLevel(string experienceToLevel);
        void SetLevelToEvolve(string levelToEvolve);
        void SetEvolvesTo(string evolvesTo);
        Item Build();
    }
}
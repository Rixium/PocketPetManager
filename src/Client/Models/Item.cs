namespace Client.Models
{
    public class Item
    {
        public int ItemId { get; init; }
        public string ItemType { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public string Description { get; init; }
        public int? ModelId { get; init; }
        public int? ExperienceToLevel { get; init; }
        public int? LevelToEvolve { get; init; }
        public int? EvolvesTo { get; init; }
    }
}
namespace Client.Models
{
    public class Item
    {
        public int ItemId { get; init; }
        public string ItemType { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public string Description { get; init; }
        public long? ModelId { get; init; }
        public long? ExperienceToLevel { get; init; }
        public long? LevelToEvolve { get; init; }
        public long? EvolvesTo { get; init; }
    }
}
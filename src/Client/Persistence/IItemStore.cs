using System.Collections.Generic;
using Client.Models;

namespace Client.Persistence
{
    public interface IItemStore
    {
        void Create(string filePath);
        void ReadFromFile(string filePath);
        void Read();
        void SaveToFile(string filePath);
        void SaveAsLua(string filePath);
        void Save();
        void Add(Item item);
        IReadOnlyCollection<Item> Get();
    }
}
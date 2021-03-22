using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text.Json;
using Client.Models;
using Luaon.Json;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Client.Persistence
{
    internal class ItemStore : IItemStore
    {
        private string _itemStorePath;
        private IList<Item> _items = new List<Item>();

        public void Create(string filePath)
        {
            _itemStorePath = filePath;

            if (File.Exists(filePath))
            {
                return;
            }

            File.Create(filePath).Dispose();
        }

        public void ReadFromFile(string filePath)
        {
            var fileText = File.ReadAllText(filePath);
            try
            {
                _items = JsonSerializer.Deserialize<IList<Item>>(fileText);
            }
            catch (JsonException)
            {
                // Ignored, File is probably empty
            }

            _itemStorePath = filePath;
        }

        public void Read() => ReadFromFile(_itemStorePath);

        public void SaveToFile(string filePath)
        {
            var fileText = JsonSerializer.Serialize(_items, new JsonSerializerOptions
            {
                IgnoreNullValues = true
            });

            File.WriteAllText(filePath, fileText);

            _itemStorePath = filePath;
        }

        public void SaveAsLua(string filePath)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            using var stringWriter = new StringWriter();
            using (var jlw = new JsonLuaWriter(stringWriter)
            {
                CloseOutput = false,
                Formatting = Formatting.Indented
            })
            {
                serializer.Serialize(jlw, _items);
            }

            File.WriteAllText(filePath, stringWriter.ToString());
        }

        public void Save() => SaveToFile(_itemStorePath);

        public void Add(Item item) => _items.Add(item);

        public IReadOnlyCollection<Item> Get() => _items.ToImmutableList();

        public void Update(Item item)
        {
            for (var i = 0; i < _items.Count; i++)
            {
                var currItem = _items[i];
                if (currItem.ItemId != item.ItemId)
                {
                    continue;
                }

                _items[i] = item;
                break;
            }
        }
    }
}
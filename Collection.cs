using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Collectatron
{
    public class Collection
    {
        private readonly List<CollectionItem> _items = new();

        public const string ImagesFolder = "Images";

        public string FileLocation { get; }

        public Collection(string fileLocation)
        {
            FileLocation = fileLocation;
        }

        public IReadOnlyCollection<CollectionItem> Items => _items.AsReadOnly();

        public void LoadItems()
        {
            var json = File.ReadAllText(FileLocation);
            var records = JsonSerializer.Deserialize<JsonCollectionItem[]>(json);
            if (records != null)
            {
                foreach (var record in records)
                {
                    var id = record.Id ?? throw new Exception("Found a record without an id!");

                    if (_items.Any(i => i.Id == id))
                    {
                        throw new Exception("Duplicate id: " + id);
                    }

                    var title = record.Title ?? "Item " + id + " (fallback)";
                    var item = new CollectionItem(this, id)
                    {
                        Title = title,
                        Brand = record.Brand,
                        PricePaid = record.PricePaid,
                        EstimatedValue = record.EstimatedValue,
                        Year = record.Year,
                        Location = record.Location,
                        Comments = record.Comments,
                        ImageExtension = record.ImageExtension
                    };

                    _items.Add(item);
                }
            }
        }

        public void SaveItems()
        {
            if (string.IsNullOrWhiteSpace(FileLocation))
            {
                throw new InvalidOperationException("No file was ever specified!");
            }

            var jsonItemList = _items.Select(i => new JsonCollectionItem
            {
                Id = i.Id,
                Title = i.Title,
                Brand = i.Brand,
                PricePaid = i.PricePaid,
                EstimatedValue = i.EstimatedValue,
                Year = i.Year,
                Location = i.Location,
                Comments = i.Comments,
                ImageExtension = i.ImageExtension
            }).ToList();

            var jsonString = JsonSerializer.Serialize(jsonItemList);

            File.WriteAllText(FileLocation, jsonString);
        }

        public CollectionItem AddItem()
        {
            var item = new CollectionItem(this, GetNextId());
            _items.Add(item);
            return item;
        }

        public void RemoveItem(CollectionItem item)
        {
            _items.Remove(item);
        }

        public string GetImagesLocation()
        {
            if (string.IsNullOrWhiteSpace(FileLocation))
            {
                throw new InvalidOperationException("No file was ever specified!");
            }

            var ext = Path.GetExtension(FileLocation);

            var path = Path.Combine(FileLocation[..^ext.Length], ImagesFolder);
            Directory.CreateDirectory(path);
            return path;
        }

        private int GetNextId()
        {
            if (_items.Count == 0)
            {
                return 0;
            }

            var highestId = _items.Max(ci => ci.Id);
            return highestId + 1;
        }
    }
}

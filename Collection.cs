using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Collectatron
{
    public class Collection
    {
        private List<CollectionItem> _items = new();

        public const string ImagesFolder = "Images";

        public string FileLocation { get; }

        public Collection(string fileLocation)
        {
            FileLocation = fileLocation;
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

        public void Clear()
        {
            _items.Clear();
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

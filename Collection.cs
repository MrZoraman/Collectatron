using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Collectatron
{
    internal class Collection
    {
        private List<CollectionItem> _items = new();

        public const string ImagesFolder = "Images";

        public string FileLocation { get; set; }

        public Collection()
        {
            Directory.CreateDirectory(ImagesFolder);
        }

        public void LoadItems()
        {
        }

        public void SaveItems()
        {
            if (string.IsNullOrWhiteSpace(FileLocation))
            {
                throw new InvalidOperationException("No file was ever specified!");
            }
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

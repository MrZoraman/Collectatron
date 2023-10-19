using System.Collections.Generic;
using System.Linq;

namespace Collectatron
{
    internal class Collection
    {
        private List<CollectionItem> _items = new();

        public void LoadItems()
        {
            var item1 = AddItem();
            item1.Name = "Item 1";
        }

        public CollectionItem AddItem()
        {
            var item = new CollectionItem(this, GetNextId());
            _items.Add(item);
            return item;
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

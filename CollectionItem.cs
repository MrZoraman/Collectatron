using System.IO;

namespace Collectatron
{
    public class CollectionItem
    {
        public CollectionItem(Collection collection, int id)
        {
            _collection = collection;
            Id = id;

            Title = "Item " + Id;
        }

        private readonly Collection _collection;

        public int Id { get; }

        public string Title { get; set; }

        public string? Brand { get; set; }

        public decimal? PricePaid { get; set; }

        public decimal? EstimatedValue { get; set; }

        public int? Year { get; set; }

        public string? Location { get; set; }

        public string? Comments { get; set; }

        public string? ImageExtension { get; set; }

        public string GetImagePath()
        {
            string folder;
            if (Id < 100)
            {
                folder = "0-99";
            }
            else if (Id < 200)
            {
                folder = "100-199";
            }
            else if (Id < 300)
            {
                folder = "200-299";
            }
            else if (Id < 400)
            {
                folder = "300-399";
            }
            else
            {
                folder = "Over 400";
            }

            var path = Path.Combine(_collection.GetImagesLocation(), folder);
            Directory.CreateDirectory(path);

            return path;
        }

        public void RemoveFromCollection()
        {
            _collection.RemoveItem(this);
        }
    }
}

using System.IO;

namespace Collectatron
{
    public class CollectionItem
    {
        private const int MaxImageFolders = 128;

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
            var folder = Id % MaxImageFolders;

            var path = Path.Combine(_collection.GetImagesLocation(), folder.ToString());
            Directory.CreateDirectory(path);

            return path;
        }

        public void RemoveFromCollection()
        {
            _collection.RemoveItem(this);
        }
    }
}

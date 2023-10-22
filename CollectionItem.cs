namespace Collectatron
{
    internal class CollectionItem
    {
        public CollectionItem(Collection collection, int id)
        {
            _collection = collection;
            Id = id;

            Name = "Item " + Id;
        }

        private readonly Collection _collection;

        public int Id { get; }

        public string Name { get; set; }

        public decimal? PricePaid { get; set; }

        public decimal? EstimatedValue { get; set; }

        public int? Year { get; set; }

        public string Comments { get; set; } = string.Empty;

        public void RemoveFromCollection()
        {
            _collection.RemoveItem(this);
        }
    }
}

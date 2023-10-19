namespace Collectatron
{
    internal class CollectionItem
    {
        public CollectionItem(Collection collection, int id)
        {
            _collection = collection;
            Id = id;
        }

        private readonly Collection _collection;

        public int Id { get;} = 0;

        public string Name { get; set; } = string.Empty;

        public decimal? PricePaid { get; set; }

        public decimal? EstimatedValue { get; set; }

        public int? Year { get; set; }

        public string Comments { get; set; } = string.Empty;
    }
}

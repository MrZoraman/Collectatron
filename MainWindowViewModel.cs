using System.Collections.ObjectModel;

namespace Collectatron
{
    internal class MainWindowViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string PricePaid { get; set; } = string.Empty;

        public string EstimatedValue { get; set; } = string.Empty;

        public ObservableCollection<CollectionListItemViewModel> CollectionItems { get; set; } = new()
        {
            new CollectionListItemViewModel(),
            new CollectionListItemViewModel(),
            new CollectionListItemViewModel(),
            new CollectionListItemViewModel()
        };
    }
}

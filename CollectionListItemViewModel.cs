using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Collectatron
{
    internal class CollectionListItemViewModel : INotifyPropertyChanged
    {
        public CollectionListItemViewModel(CollectionItem item, ObservableCollection<CollectionListItemViewModel> itemList)
        {
            _item = item;
            RemoveItemCommand = new RemoveItemCommand(this, itemList);
        }

        private readonly CollectionItem _item;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Title
        {
            get => _item.Name;
            set
            {
                _item.Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public int Id => _item.Id;

        public RemoveItemCommand RemoveItemCommand { get; }

        public void RemoveFromCollection()
        {
            _item.RemoveFromCollection();
        }
    }
}

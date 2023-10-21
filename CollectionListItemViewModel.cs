using System.ComponentModel;

namespace Collectatron
{
    internal class CollectionListItemViewModel : INotifyPropertyChanged
    {
        public CollectionListItemViewModel(CollectionItem item)
        {
            _item = item;
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
    }
}

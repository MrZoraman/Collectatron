﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Collectatron
{
    public class CollectionListItemViewModel : INotifyPropertyChanged
    {
        public CollectionListItemViewModel(CollectionItem item, ObservableCollection<CollectionListItemViewModel> itemList)
        {
            _item = item;
            RemoveItemCommand = new RemoveItemCommand(this, itemList);

            var imagePath = Path.Combine(item.GetImagePath(), item.Id + item.ImageExtension);
            if (File.Exists(imagePath))
            {
                _image = new BitmapImage(new Uri(imagePath));
            }
        }

        private readonly CollectionItem _item;

        public event PropertyChangedEventHandler? PropertyChanged;

        private BitmapImage? _image;

        public string Title
        {
            get => _item.Title;
            set
            {
                _item.Title = string.IsNullOrEmpty(value)
                    ? "Item " + _item.Id
                    : value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public string? Brand
        {
            get => _item.Brand;
            set
            {
                _item.Brand = string.IsNullOrEmpty(value)
                    ? null
                    : value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Brand)));
            }
        }

        public string? PricePaid
        {
            get => _item.PricePaid?.ToString() ?? string.Empty;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _item.PricePaid = null;
                }
                else
                {
                    try
                    {
                        _item.PricePaid = decimal.Parse(value);
                    }
                    catch
                    {
                        MessageBox.Show("Not a number: " + value, "Not a number!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PricePaid)));
            }
        }

        public string? Year
        {
            get => _item.Year?.ToString() ?? string.Empty;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _item.Year = null;
                }
                else
                {
                    try
                    {
                        _item.Year = int.Parse(value);
                    }
                    catch
                    {
                        MessageBox.Show("Not a number: " + value, "Not a number!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Year)));
            }
        }

        public string? EstimatedValue
        {
            get => _item.EstimatedValue?.ToString() ?? string.Empty;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _item.EstimatedValue = null;
                }
                else
                {
                    try
                    {
                        _item.EstimatedValue = decimal.Parse(value);
                    }
                    catch
                    {
                        MessageBox.Show("Not a number: " + value, "Not a number!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstimatedValue)));
            }
        }

        public string? Location
        {
            get => _item.Location;
            set
            {
                _item.Location = string.IsNullOrEmpty(value)
                    ? null
                    : value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Location)));
            }
        }

        public string? Comments
        {
            get => _item.Comments;
            set
            {
                _item.Comments = string.IsNullOrEmpty(value)
                    ? null
                    : value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Comments)));
            }
        }

        public BitmapImage? Image
        {
            get => _image;
            set
            {
                _image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
            }
        }

        public int Id => _item.Id;

        public RemoveItemCommand RemoveItemCommand { get; }

        public void RemoveFromCollection()
        {
            _item.RemoveFromCollection();
        }

        public string GetImagePath()
        {
            return _item.GetImagePath();
        }

        public void SetExtension(string extension)
        {
            _item.ImageExtension = extension;
        }
    }
}

﻿using FlickrView.Business.Interfaces;
using FlickrView.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace FlickrView.UI.ViewModels
{
    public class FlickrViewModel : INotifyPropertyChanged
    {
        FlickrModel _flickrModel;
        public FlickrViewModel()
        {
            _flickrModel = new FlickrModel();
            IList<string> list = _flickrModel.GetSources();
            _sourcesEntries = new ObservableCollection<string>(list);
            _searchTags = "";
        }

        private ObservableCollection<string> _sourcesEntries;
        private ObservableCollection<ImageSource> _images;
        private string _sourcesEntry;
        private string _searchTags;
        public string SearchTags 
        {
            get { return _searchTags; } 
            set { if (_searchTags == value) return;
                _searchTags = value;
                OnPropertyChanged("SearchTags");
            } 
        }
        public ObservableCollection<string> SourcesEntries
        {
            get { return _sourcesEntries; }
        }
        public ObservableCollection<ImageSource> Images
        {
            get { return _images; }
            set
            {
                if (_images == value) return;
                _images = value;
                OnPropertyChanged("Images");
            }
        }

        public string SourcesEntry
        {
            get { return _sourcesEntry; }
            set
            {
                if (_sourcesEntry == value) return;
                _sourcesEntry = value;
                OnPropertyChanged("SourcesEntry");
            }
        }
        public void SearchImages()
        {
            if(SearchTags != "" && SourcesEntry != "")
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    var resultArray = _flickrModel.SearchImages(SearchTags, SourcesEntry);
                    var displayList = new List<ImageSource>();
                    Parallel.ForEach(resultArray, (currentArray) => { displayList.Add(ToImage(currentArray)); });                   
                    Images = new ObservableCollection<ImageSource>(displayList);
                }));
                
            }
           
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.DecodePixelHeight = 150;
                image.DecodePixelWidth = 200;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

using FlickrView.Business.Concrete;
using FlickrView.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlickrView.UI.Models
{
    public class FlickrModel
    {
        IFlickrConfiguration config;
        public FlickrModel()
        {
            config = new FlickrConfiguration();
        }
        public List<string> GetSources()
        {
            return config.GetAllSources();
        }
        public List<byte[]> SearchImages(string tags, string source)
        {
            SearchRequest searchRequest = new SearchRequest();
            var result = searchRequest.GetSearchResults(tags, source);
            return result;
        }

    }
    public class FlickrImages
    {
        public Image Image { get; set; }
    }
}

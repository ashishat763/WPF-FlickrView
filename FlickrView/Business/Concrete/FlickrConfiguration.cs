using FlickrView.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrView.Business.Concrete
{
    public class FlickrConfiguration : IConfiguration
    {
        private static readonly string url = @"https://www.flickr.com/services/feeds/photos_public.gne";
        private static readonly string source = "Flickr";
        public string GetAppSettings(string key)
        {
            return url;
        }
        public List<string> GetAllSources()
        {
            List<string> sources = new List<string>();
            sources.Add(source);
            return sources;
        }
    }
}

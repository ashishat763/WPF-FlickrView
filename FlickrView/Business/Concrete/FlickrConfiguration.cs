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
            //As of now, this is hardcoded. Eventually, we can provide a Config form where user can
            // add other public api and we can store/get the data from Db
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

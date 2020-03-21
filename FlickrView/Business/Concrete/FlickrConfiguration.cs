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
        public string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key]; ;
        }
        public List<string> GetAllSources()
        {
            List<string> sources = new List<string>();
            foreach(var appSources in ConfigurationManager.AppSettings.Keys)
            {
                sources.Add(appSources.ToString());
            }
            return sources;
        }
    }
}

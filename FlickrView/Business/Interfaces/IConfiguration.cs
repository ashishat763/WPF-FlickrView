using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrView.Business.Interfaces
{
    public interface IConfiguration
    {
        //Get specific Uri(value) corresponding to source(key)
        string GetAppSettings(string key);
        //Get all sources
        List<string> GetAllSources();
    }
}

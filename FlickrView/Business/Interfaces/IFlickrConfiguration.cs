using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrView.Business.Interfaces
{
    public interface IFlickrConfiguration
    {
        string GetAppSettings(string key);
        List<string> GetAllSources();
    }
}

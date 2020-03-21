using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlickrView.Business.Interfaces
{
    public interface IConnection
    {
        HttpClient GetNewHttpClient();
        string GetResponseString(HttpClient client, string requestUri);
        byte[] DownloadImage(string fromUrl);
    }
}

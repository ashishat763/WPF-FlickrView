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
        //Return new HttpClient for connection
        HttpClient GetNewHttpClient();
        //return a response string from Uri
        string GetResponseString(HttpClient client, string requestUri);
        //Download image in byte[]
        byte[] DownloadImage(string fromUrl);
    }
}

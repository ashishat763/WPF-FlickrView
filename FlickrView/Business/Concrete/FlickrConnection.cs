using FlickrView.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FlickrView.Business.Concrete
{
    public class FlickrConnection : IFlickrConnection
    {       
        public HttpClient GetNewHttpClient()
        {
            return new HttpClient();
        }
        public string GetResponseString(HttpClient client, string requestUri)
        {
            Task<string> result = GetResponse(client, requestUri);
            result.Wait();
            return result.Result;
        }
        private async Task<string> GetResponse(HttpClient client, string requestUri)
        {           
            string jsonstring = await client.GetStringAsync(requestUri).ConfigureAwait(false);
            return jsonstring;
        }

        public byte[] DownloadImage(string fromUrl)
        {
            try
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    webClient.Proxy = null;
                    using (Stream stream = webClient.OpenRead(fromUrl))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            stream.CopyTo(ms);
                            return ms.ToArray();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}

using FlickrView.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;

namespace FlickrView.Business.Concrete
{
    public class SearchRequest
    {
        IConnection conn;
        IConfiguration config;
        public SearchRequest() : this(new FlickrConnection(), new FlickrConfiguration())
        {

        }
        public SearchRequest(IConnection connection, IConfiguration configuration)
        {
            conn = connection;
            config = configuration;
        }

        public List<byte[]> GetSearchResults(string searchString, string source)
        {
            try
            {
                List<byte[]> images = null;
                switch (source)
                {
                    case "Flickr":
                        var imageUrls = SearchFlickr(searchString, source);
                        images = new List<byte[]>();
                        Parallel.ForEach(imageUrls, (currentImg) =>
                        {
                            var img = conn.DownloadImage(currentImg);
                            if (img != null)
                            {
                                images.Add(img);
                            }
                        });
                        break;

                }
                return images;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private List<string> SearchFlickr(string searchString, string source)
        {
            try
            {
                var http = conn.GetNewHttpClient();
                string uri = config.GetAppSettings(source);
                string annotatedUri = AnnotateUrl(searchString, uri);
                string result = conn.GetResponseString(http, annotatedUri);
                List<string> imageUrls = ParseResult(result);
                return imageUrls;
            }
            catch(Exception ex)
            {
                return new List<string>();
            }
        }
        private string AnnotateUrl(string searchString, string uri)
        {
            string tags = String.Join(",", searchString.Split(' '));
            return uri + "?tags=" + tags;

        }
        public List<string> ParseResult(string result)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(result);
                XmlNodeList elemlist = xmlDocument.GetElementsByTagName("entry");
                List<string> imageUrls = new List<string>();
                Parallel.ForEach(elemlist.OfType<XmlElement>(), (element) =>
                {
                    try
                    {
                        var childs = element.ChildNodes;
                        foreach (XmlElement child in childs)
                        {
                            if (child.Name == "link" && child.HasAttributes)
                            {
                                XmlAttributeCollection xmlAttributeCollection = child.Attributes;
                                XmlNode node = xmlAttributeCollection.GetNamedItem("type");
                                if (node.Value == @"image/jpeg")
                                {
                                    XmlNode url = xmlAttributeCollection.GetNamedItem("href");
                                    imageUrls.Add(url.Value);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                });
                return imageUrls;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }


    }
}

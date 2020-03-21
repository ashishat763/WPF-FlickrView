using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using FlickrView.Business.Concrete;
using FlickrView.Business.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;


namespace FlickrViewTest
{
    [TestClass]
    public class TestConfiguration
    {
        [TestMethod]
        public void GetAppSettings_WhenCalled_VerifyreturnValue()
        {
            var config = new FlickrConfiguration();
            var result = config.GetAppSettings("Flickr");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllSources_WhenCalled_VerifyReturnValue()
        {
            var config = new FlickrConfiguration();
            List<string> result = config.GetAllSources();

            Assert.IsNotNull(result == null);
        }

    }
}

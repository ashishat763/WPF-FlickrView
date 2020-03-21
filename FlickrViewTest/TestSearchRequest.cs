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
    public class TestSearchRequest
    {
        [TestMethod]
        [DeploymentItem(@"TestData", "TestData")]
        public void ParseResult_WhenCalled_VerifyReturnValue()
        {
            //ARRANGE
            var mockConnection = MockRepository.GenerateMock<IConnection>();
            var mockConfiguration = MockRepository.GenerateMock<IConfiguration>();
            SearchRequest searchRequest = new SearchRequest(mockConnection, mockConfiguration);
            var testData = GetUrlStrings();
            var testHash = new HashSet<string>(testData);

            //ACT
            var result = searchRequest.ParseResult(GetResponseString());
            var resultHash = new HashSet<string>(result);

            //ASSERT
            Assert.IsTrue(resultHash.SetEquals(testHash));
        }

        [TestMethod]
        [DeploymentItem(@"TestData", "TestData")]
        public void GetSearchResult_WhenCalled_VerifyReturnValue()
        {
            //ARRANGE
            var mockConnection = MockRepository.GenerateMock<IConnection>();
            var mockConfiguration = MockRepository.GenerateMock<IConfiguration>();
            SearchRequest searchRequest = new SearchRequest(mockConnection, mockConfiguration);
            var http = new HttpClient();
            var uri = "TestUri";
            var responseString = GetResponseString();
            byte[] downloadByte = new byte[20];
            mockConnection.Stub(mc => mc.GetNewHttpClient()).Return(http);
            mockConfiguration.Stub(mc => mc.GetAppSettings("TestKey")).IgnoreArguments().Return(uri);
            mockConnection.Stub(mc => mc.GetResponseString(http, uri)).IgnoreArguments().Return(responseString);
            mockConnection.Stub(mc => mc.DownloadImage("TestUrl")).IgnoreArguments().Return(downloadByte).Repeat.Any();

            //ACT
            List<byte[]> result = searchRequest.GetSearchResults("nature", "Flickr");

            //ASSERT
            Assert.IsTrue(result.Count == 20);

        }
        private static string GetPath()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "Test.txt");
        }
        private static string GetResponseString()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "Test.txt");
            string myXml = File.ReadAllText(path);
            return myXml;
        }
        private static string[] GetUrlStrings()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "Out.txt");
            string myXml = File.ReadAllText(path);
            return myXml.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

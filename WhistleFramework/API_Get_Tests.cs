using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace WhistleFramework
{
    [TestFixture]
    public class GetTests
    {
        RestClient client;
        RestRequest request;

        [SetUp]
        public void Settup()
        {
            request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Host", "sdet-interview-api.herokuapp.com");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
        }

        [Test]
        public void Get_All_Devices_States()
        {
            //Set Up Phase
            var endPoint = "/device_state";

            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint);
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "OK", $"Status code OK(200) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsNotEmpty(response.Content, $"Response from API was empty <Actual Response>:{response.Content}");
            });
        }

        [Test]
        public void Get_Device_By_Id_Returned_200()
        {
            //Set Up Phase
            var endPoint = "/device_state";
            var resource = "/4";

            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + resource);
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "OK", $"Status code OK(200) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsTrue(response.Content.Contains("4"), $"Response from API was empty <Actual Response>:{response.Content}");
            });
        }

        [Test]
        public void Get_Device_By_Id_Returned_404()
        {
            //Set Up Phase
            var endPoint = "/device_state";
            var resource = "/40000";
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + resource);

            //Execution Phase
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple( () =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "NotFound", $"Status code NOT FOUND(404) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }
    }
}
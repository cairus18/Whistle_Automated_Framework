using NUnit.Framework;
using RestSharp;
using WhistleFramework.src.Helpers;

namespace WhistleFramework
{
    [TestFixture]
    public class GetTests
    {
        RestClient client;
        RestRequest request;
        APIHelper apiHelp;

        [SetUp]
        public void Settup()
        {
            apiHelp = new APIHelper();
            request = new RestRequest(Method.GET);
            request.AddHeader("Host", "sdet-interview-api.herokuapp.com");
            request.AddHeader("Content-Type", "application/json");
        }

        [TestCase("/device_state")]
        public void Get_All_Devices_States(string endPoint)
        {
            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint);
            IRestResponse response = client.Execute(request);
            var (wasItTrue, deviceId) = apiHelp.ValidateItemsAreSortedByDateAsc(response.Content);
            
            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "OK", $"Status code OK(200) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsTrue(wasItTrue, $"Not all the items were ordered by timestamp ascending device without order:{deviceId}");
            });
        }

        [TestCase("/device_state", "/4")]
        public void Get_Device_By_Id_Returned_200(string endPoint, string resource)
        {
            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + resource);
            IRestResponse response = client.Execute(request);
            var (wasItTrue, deviceId) = apiHelp.ValidateItemsAreSortedByDateAsc(response.Content);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "OK", $"Status code OK(200) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsTrue(wasItTrue, $"Not all the items were ordered by timestamp ascending device without order:{deviceId}");
            });
        }

        [TestCase("/device_state", "/40000")]
        public void Get_Device_By_Id_Returned_404(string endPoint, string resource)
        {

            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + resource);
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
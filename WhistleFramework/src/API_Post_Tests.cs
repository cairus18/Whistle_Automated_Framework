using NUnit.Framework;
using RestSharp;
using WhistleFramework.src.Helpers;

namespace WhistleFramework
{ 
    [TestFixture]
    public class PostTests
    {
        RestClient client;
        RestRequest request;
        APIHelper apiHelp;

        [SetUp]
        public void Settup()
        {
            request = new RestRequest(Method.POST);
            request.AddHeader("Host", "sdet-interview-api.herokuapp.com");
            request.AddHeader("Content-Type", "application/json");
        }

        [TestCase("/device_state", "4", "track")]
        public void Create_Device_Returned_200(string endPoint, string paramDeviceId, string paramEvent)
        {
            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "OK", $"Status code OK(200) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsNotEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [TestCase("/device_state")]
        public void Creating_New_Device_With_No_Parameters_Returned_400(string endPoint)
        {
            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint);
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [TestCase("/device_state", "", "")]
        public void Creating_New_Device_With_Empty_Parameters_Returned_400(string endPoint, string paramDeviceId, string paramEvent)
        {
            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [TestCase("/device_state", "10", "")]
        public void Creating_New_Device_Just_Device_Id_Parameters_Provided_Returned_400(string endPoint, string paramDeviceId, string paramEvent)
        {
            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [TestCase("/device_state", "", "Tracker")]
        public void Creating_New_Device_Just_Event_Parameters_Provided_Returned_400(string endPoint, string paramDeviceId, string paramEvent)
        {
            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [TestCase("/device_state", "-12", "Tracker")]
        public void Creating_New_Device_With_Negative_Values_For_Device_Id_Parameter_Provided_Returned_400(string endPoint, string paramDeviceId, string paramEvent)
        {
            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [TestCase("/device_state", "34239048233423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124", "Tracker")]
        public void Creating_New_Device_With_Big_Device_Id_Parameter_Provided_Returned_400(string endPoint, string paramDeviceId, string paramEvent)
        {
            //Execution Phase
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }
    }
}
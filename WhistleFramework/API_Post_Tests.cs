using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace WhistleFramework
{
    [TestFixture]
    public class PostTests
    {
        RestClient client;
        RestRequest request;

        [SetUp]
        public void Settup()
        {
            request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Host", "sdet-interview-api.herokuapp.com");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
        }

       
        [Test]
        public void Create_Device_Returned_200()
        {
            //Set Up Phase
            var endPoint = "/device_state";
            var paramDeviceId = "9";
            var paramEvent = "hover";
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);
    
            //Execution Phase
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "OK", $"Status code OK(200) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsNotEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [Test]
        public void Creating_New_Device_With_No_Parameters_Returned_400()
        {
            //Set Up Phase
            var endPoint = "/device_state";
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint);

            //Execution Phase
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [Test]
        public void Creating_New_Device_With_Empty_Parameters_Returned_400()
        {
            //Set Up Phase
            var endPoint = "/device_state";
            var paramDeviceId = "";
            var paramEvent = "";
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);

            //Execution Phase
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [Test]
        public void Creating_New_Device_Just_Device_Id_Parameters_Provided_Returned_400()
        {
            //Set Up Phase
            var endPoint = "/device_state";
            var paramDeviceId = "10";
            var paramEvent = "";
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);

            //Execution Phase
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [Test]
        public void Creating_New_Device_Just_Event_Parameters_Provided_Returned_400()
        {
            //Set Up Phase
            var endPoint = "/device_state";
            var paramDeviceId = "";
            var paramEvent = "Tracker";
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);

            //Execution Phase
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [Test]
        public void Creating_New_Device_With_Negative_Values_For_Device_Id_Parameter_Provided_Returned_400()
        {
            //Set Up Phase
            var endPoint = "/device_state";
            var paramDeviceId = "-12";
            var paramEvent = "Tracker";
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);

            //Execution Phase
            IRestResponse response = client.Execute(request);

            //Assert Phase
            Assert.Multiple(() =>
            {
                Assert.AreEqual(response.StatusCode.ToString(), "BadRequest", $"Status code Bad Request(400) was expected but <Actual Response>:{response.StatusCode} as provided");
                Assert.IsEmpty(response.Content, $"Response from API was Not empty <Actual Response>:{response.Content}");
            });
        }

        [Test]
        public void Creating_New_Device_With_Big_Device_Id_Parameter_Provided_Returned_400()
        {
            //Set Up Phase
            var endPoint = "/device_state";
            var paramDeviceId = "34239048233423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124342390482309842309842309840932849023840932840923840923849023480923480923482309481290347598123759812434239048230984230984230984093284902384093284092384092384902348092348092348230948129034759812375981243423904823098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124098423098423098409328490238409328409238409238490234809234809234823094812903475981237598124";
            var paramEvent = "Tracker";
            client = new RestClient("http://sdet-interview-api.herokuapp.com" + endPoint + "?device_id=" + paramDeviceId + "&event=" + paramEvent);

            //Execution Phase
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
using BusinessLayer;
using BusinessLayer.interfaces;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using powerplant_coding_challenge_api;
using powerplant_coding_challenge_api.Controllers;
using System.Collections.Generic;
using System.Net.Http;
using TestProject.TestUtils;

namespace TestProject
{
    [TestClass]
    public class PowerpantControllerTest
    {
        private TestServer server;
        private HttpClient _client;
        private string controllerUrl;
        Mock<IPowerplantManager> powerplantManagerMock;
        Mock<IProductionPlanManager> productionPlanManagerMock;

        [TestInitialize]
        public void Initialize()
        {
            powerplantManagerMock = new Mock<IPowerplantManager>();
            powerplantManagerMock.Setup(pmm => pmm.InitializePowerplantProcessers(It.IsAny<Payload>()))
                .Returns(new List<IEnergyProducer>());

            productionPlanManagerMock = new Mock<IProductionPlanManager>();

            _client = GetClient();
            controllerUrl = "https://localhost:44390/ProductionPlan";
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetExpectedHardcodedAnswerAsync()
        {
            //
            var expected = "value";

            //
            var response = await _client.GetAsync($"{controllerUrl}/1");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = content.ToString();

            //
            Assert.AreEqual(expected.ToString(), result);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task NoResultFromProductionPlanManagerReturnsNoContent()
        {
            //
            productionPlanManagerMock.
                Setup(ppmm => ppmm.PerformCalculation(It.IsAny<List<IEnergyProducer>>(), It.IsAny<int>()))
                .Returns(new List<Domain.ProductionPlan>());
            var httpContent = DummyObjectFactory.GetEmptySerializedPayload();

            //
            var response = await _client.PostAsync($"{controllerUrl}", httpContent);

            //
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ProductionPlanControllerReturnInternalError()
        {
            //
            var httpContent = DummyObjectFactory.GetEmptySerializedPayload();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            _client = GetFakeClient(productionPlanManagerMock, powerplantManagerMock);
            httpRequestMessage.Content = httpContent;

            //
            var response = await _client.PostAsync($"{controllerUrl}", httpContent);

            //
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ProductionPlanControllerReturnsValidPayload()
        {
            //
            HttpContent httpContent = DummyObjectFactory.GetDummySerializedPayload();

            //
            var response = await _client.PostAsync($"{controllerUrl}", httpContent);

            //
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ProductionPlanControllerReturnsUnsupportedMediaType()
        {
            //
            productionPlanManagerMock.
                Setup(ppmm => ppmm.PerformCalculation(It.IsAny<List<IEnergyProducer>>(), It.IsAny<int>())).Throws(new System.Exception());
            var httpContent = DummyObjectFactory.GetEmptySerializedPayload();
            httpContent = null;

            //
            var response = await _client.PostAsync($"{controllerUrl}", httpContent);

            //
            Assert.AreEqual(System.Net.HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        private static HttpClient GetFakeClient(Mock<IProductionPlanManager> productionPlanManagerMock, Mock<IPowerplantManager> powerplantManagerMock)
        {
            var builder = new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>().ConfigureTestServices(services =>
            {
                services.AddSingleton(productionPlanManagerMock.Object);
            });

            TestServer server = new TestServer(builder);
            return server.CreateClient();
        }

        private static HttpClient GetClient()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>();
            TestServer server = new TestServer(builder);
            return server.CreateClient();
        }
    }
}

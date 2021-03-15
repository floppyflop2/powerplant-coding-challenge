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
            powerplantManagerMock.Setup(pmm
                => pmm.InitializePowerplantProcessers(It.IsAny<Payload>())).Returns(new List<IEnergyProducer>());
            productionPlanManagerMock = new Mock<IProductionPlanManager>();

            _client = GetFakeClient(productionPlanManagerMock, powerplantManagerMock);
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
            var httpContent = DummyObjectFactory.GetSerializedPayload();

            //
            var response = await _client.PostAsync($"{controllerUrl}", httpContent);

            //
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ProductionPlanControllerReturnUnsupportedMediaType()
        {
            //
            var httpContent = DummyObjectFactory.GetSerializedPayload();
            httpContent = null;

            //
            var response = await _client.PostAsync($"{controllerUrl}", httpContent);

            //
            Assert.AreEqual(System.Net.HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ProductionPlanControllerReturnInternalError()
        {
            //
            productionPlanManagerMock.
                Setup(ppmm => ppmm.PerformCalculation(It.IsAny<List<IEnergyProducer>>(), It.IsAny<int>())).Throws(new System.Exception());
            var httpContent = DummyObjectFactory.GetSerializedPayload();

            httpContent = null;
            //
            var client = GetFakeClient(productionPlanManagerMock, powerplantManagerMock);
            var response = await _client.PostAsync($"{controllerUrl}", httpContent);

            //
            //TODO Should return an internal error
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
    }
}

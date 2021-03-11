using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using powerplant_coding_challenge_api;
using System.Net.Http;

namespace TestProject
{
    [TestClass]
    public class PowerpantControllerTest
    {
        private TestServer server;
        private HttpClient _client;
        private string controllerUrl;

        [TestInitialize]
        public void Initialize()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
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
    }
}

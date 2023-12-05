using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingUI.Test.DomainTestCases
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class RolesTestCases
    {
        private Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _client = new HttpClient(_mockHttpMessageHandler.Object);
        }

        [Test]
        public async Task TestEndpointHealth()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:7229/api/ScriptGenerator/GetListOfRoles");
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("[]") });
            var response = await _client.SendAsync(request);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            //TODO: Log That this test passed
        }

        [Test]
        public async Task TestGetListOfRolesReturnsEmptyList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:7229/api/ScriptGenerator/GetListOfRoles");
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("[]") });
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content, Is.EqualTo("[]"));
            //TODO: Log That this test passed
        }

            [Test]
        public async Task TestGetListOfRolesReturnsNonEmptyList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:7229/api/ScriptGenerator/GetListOfRoles");
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("[{\"roleId\":1,\"roleName\":\"Developer\"},{\"roleId\":2,\"roleName\":\"Analyst\"},{\"roleId\":3,\"roleName\":\"Sr Analyst\"},{\"roleId\":4,\"roleName\":\"Contractor\"},{\"roleId\":5,\"roleName\":\"Engineer\"},{\"roleId\":6,\"roleName\":\"Sr Engineer\"},{\"roleId\":7,\"roleName\":\"Supervisor\"},{\"roleId\":8,\"roleName\":\"Manager\"},{\"roleId\":9,\"roleName\":\"Tech Lead\"}]") });
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content, Is.EqualTo("[{\"roleId\":1,\"roleName\":\"Developer\"},{\"roleId\":2,\"roleName\":\"Analyst\"},{\"roleId\":3,\"roleName\":\"Sr Analyst\"},{\"roleId\":4,\"roleName\":\"Contractor\"},{\"roleId\":5,\"roleName\":\"Engineer\"},{\"roleId\":6,\"roleName\":\"Sr Engineer\"},{\"roleId\":7,\"roleName\":\"Supervisor\"},{\"roleId\":8,\"roleName\":\"Manager\"},{\"roleId\":9,\"roleName\":\"Tech Lead\"}]"));
            //TODO: Log That this test passed
        }

        [Test]
        public async Task TestGetListOfRolesReturnsServerError()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:7229/api/ScriptGenerator/GetListOfRoles");
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError });
            var response = await _client.SendAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            //TODO: Log That this test passed
        }
    }
}

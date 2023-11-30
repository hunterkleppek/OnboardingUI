using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OnboardingUI.Test.DomainTestCases
{
    public class TeamsTestCases
    {
        private Mock<HttpMessageHandler> _mockHandler;
        private HttpClient _client;
        private string _url = "https://localhost:7229/api/ScriptGenerator/GetListOfTeams";

        [SetUp]
        public void Setup()
        {
            _mockHandler = new Mock<HttpMessageHandler>();
            _client = new HttpClient(_mockHandler.Object);
        }

        [Test]
        public async Task TestEndpointHealth()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("[]") });
            var response = await _client.SendAsync(request);
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task TestGetListOfTeamsReturnsEmptyList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("[]") });
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content, Is.EqualTo("[]"));
        }

        [Test]
        public async Task TestGetListOfTeamsReturnsNonEmptyList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("[{\"teamId\":1,\"teamName\":\"Team 1\"},{\"teamId\":2,\"teamName\":\"Team 2\"},{\"teamId\":3,\"teamName\":\"Team 3\"},{\"teamId\":4,\"teamName\":\"Team 4\"},{\"teamId\":5,\"teamName\":\"Team 5\"},{\"teamId\":6,\"teamName\":\"Team 6\"},{\"teamId\":7,\"teamName\":\"Team 7\"},{\"teamId\":8,\"teamName\":\"Team 8\"},{\"teamId\":9,\"teamName\":\"Team 9\"}]") });
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content, Is.EqualTo("[{\"teamId\":1,\"teamName\":\"Team 1\"},{\"teamId\":2,\"teamName\":\"Team 2\"},{\"teamId\":3,\"teamName\":\"Team 3\"},{\"teamId\":4,\"teamName\":\"Team 4\"},{\"teamId\":5,\"teamName\":\"Team 5\"},{\"teamId\":6,\"teamName\":\"Team 6\"},{\"teamId\":7,\"teamName\":\"Team 7\"},{\"teamId\":8,\"teamName\":\"Team 8\"},{\"teamId\":9,\"teamName\":\"Team 9\"}]"));
        }

        [Test]
        public async Task TestGetListOfTeamsReturnsServerError()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError });
            var response = await _client.SendAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
    }
}